using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Evans.Blog.Blogs;
using Evans.Blog.Blogs.DomainServices;
using Evans.Blog.Blogs.Repositories;
using Evans.Blog.CategoryTags.Repositories;
using Evans.Blog.Consts;
using Evans.Blog.Domain.Shared.Dto;
using Evans.Blog.Dto;
using Evans.Blog.Services;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.ServiceImpl
{
    //[Authorize(BlogPermissions.Posts.Default)]
    public class PostAppService : BlogAppService, IPostAppService
    {
        private readonly IPostRepository _postRepository;
        private readonly PostManager _postManager;
        private readonly ICategoryRepository _categoryRepository;

        public PostAppService(
            IPostRepository postRepository,
            PostManager postManager,
            ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
            _postManager = postManager;
            _categoryRepository = categoryRepository;
        }
        
        public async Task<ServiceResult<PostDto>> GetAsync(Guid id)
        {
            var result = new ServiceResult<PostDto>();

            return await Cache4PostDto.GetOrAddAsync(
                id.ToString(),
                async () => await GetFromDatabaseAsync(id,result),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(CacheStrategyConst.ONE_DAY),
                    
                });
        }

        public async Task<ServiceResult<PagedResultDto<PostDto>>> GetListAsync(GetPostListDto input)
        {
            var result = new ServiceResult<PagedResultDto<PostDto>>();
            var key = $"getPostList_{input.MaxResultCount}_{input.SkipCount}_{input.Filter}";
            
            return await Cache4PagedResultDtoPostDto.GetOrAddAsync(
                key, 
                async () => await GetListFromDatabaseAsync(input,result),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(CacheStrategyConst.ONE_DAY)
                });
        }

        
        //[Authorize(BlogPermissions.Posts.Create)]
        public async Task<ServiceResult<PostDto>> CreateAsync(CreateUpdatePostDto input)
        {
            var result = new ServiceResult<PostDto>();
            
            var post = await _postManager.CreatePostAsync(
                input.Title,
                input.Author,
                input.Url,
                input.Html,
                input.Avatar,
                input.Markdown,
                input.CategoryId);

            await _postRepository.InsertAsync(post);
            
            return result.IsSuccess(ObjectMapper.Map<Post, PostDto>(post));
        }

        //[Authorize(BlogPermissions.Posts.Edit)]
        public async Task<ServiceResult<string>> UpdateAsync(Guid id, CreateUpdatePostDto input)
        {
            var result = new ServiceResult<string>();

            await Cache4PostDto.RemoveAsync(id.ToString());
            
            var post = await _postRepository.GetAsync(id);

            post.Title = input.Title;
            post.Author = input.Author;
            post.Url = input.Url;
            post.Html = input.Html;
            post.Avatar = input.Avatar;
            post.Markdown = input.Markdown;
            post.CategoryId = input.CategoryId;

            await _postRepository.UpdateAsync(post);

            await Task.Delay(500);

            await Cache4PostDto.RemoveAsync(id.ToString());

            return result.IsSuccess();
        }

        //[Authorize(BlogPermissions.Posts.Delete)]
        public async Task<ServiceResult<string>> DeleteAsync(Guid id)
        {
            var result = new ServiceResult<string>();
            await _postRepository.DeleteAsync(id);

            return result.IsSuccess();
        }

        private async Task<ServiceResult<PostDto>> GetFromDatabaseAsync(Guid id, ServiceResult<PostDto> result)
        {
            // Get the IQueryable<Post> from the post repository
            var queryable = await _postRepository.GetQueryableAsync();

            // Prepare a query to join post and category
            var query =
                from post in queryable
                join category in _categoryRepository on post.CategoryId equals category.Id
                where post.Id == id
                select new {post, category};

            // Execute the query and get the post with category
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Post), id);
            }

            var postDto = ObjectMapper.Map<Post, PostDto>(queryResult.post);
            postDto.CategoryName = queryResult.category.CategoryName;

            return result.IsSuccess(postDto);
        }

        private async Task<ServiceResult<PagedResultDto<PostDto>>> GetListFromDatabaseAsync(
            GetPostListDto input,
            ServiceResult<PagedResultDto<PostDto>> result)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Post.CreationTime) + " desc";
            }

            // Get the IQueryable<Post> from the repository
            //var postQueryable = await _postRepository.GetQueryableAsync();

            // Get the IEnumerable<Post> from custom repository so that sorting,filter,paging functionality can be available.
            var posts = await _postRepository.GetListAsync(
                input.SkipCount, 
                input.MaxResultCount, 
                input.Sorting,
                input.Filter);

            // Prepare a query to join post and category
            var query =
                from post in posts
                join category in _categoryRepository on post.CategoryId equals category.Id
                select new {post, category};

            //Paging
            // query = query
            //     .Skip(input.SkipCount)
            //     .Take(input.MaxResultCount);

            // Execute the query and get a list
            // var queryResult = await AsyncExecuter.ToListAsync(query);


            // Convert the query result to a list of PostDto objects
            var postDtos = query.Select(x =>
            {
                var postDto = ObjectMapper.Map<Post, PostDto>(x.post);
                postDto.CategoryName = x.category.CategoryName;
                return postDto;
            }).ToList();

            // Get the total count with another query
            var totalCount = input.Filter.IsNullOrWhiteSpace()
                ? await _postRepository.CountAsync()
                : await _postRepository.CountAsync(p =>
                    p.Title.Contains(input.Filter) || p.Markdown.Contains(input.Filter));

            return result.IsSuccess(new PagedResultDto<PostDto>(totalCount, postDtos));
        }
    }
}
