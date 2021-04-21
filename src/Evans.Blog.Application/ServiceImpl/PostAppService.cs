using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Evans.Blog.Blogs;
using Evans.Blog.Blogs.DomainServices;
using Evans.Blog.Blogs.Repositories;
using Evans.Blog.CategoryTags.Repositories;
using Evans.Blog.Dto;
using Evans.Blog.Services;
using Volo.Abp.Application.Dtos;
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
        
        public async Task<PostDto> GetAsync(Guid id)
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

            return postDto;
        }

        public async Task<PagedResultDto<PostDto>> GetListAsync(GetPostListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Post.CreationTime) + " desc";
            }

            var posts = await _postRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter);

            var query = from post in posts
                join category in _categoryRepository on post.CategoryId equals category.Id
                select new {post, category};


            var postDtos = query.Select(p =>
            {
                var postDto = ObjectMapper.Map<Post, PostDto>(p.post);
                postDto.CategoryName = p.category.CategoryName;
                return postDto;
            }).ToList();

            var totalCount = input.Filter.IsNullOrWhiteSpace()
                ? await _postRepository.CountAsync()
                : await _postRepository.CountAsync(post =>
                    post.Title.Contains(input.Filter) || post.Markdown.Contains(input.Filter));

            return new PagedResultDto<PostDto>(totalCount, postDtos);
        }

        
        //[Authorize(BlogPermissions.Posts.Create)]
        public async Task<PostDto> CreateAsync(CreateUpdatePostDto input)
        {
            var post = await _postManager.CreatePostAsync(
                input.Title,
                input.Avatar,
                input.Url,
                input.Html,
                input.Avatar,
                input.Markdown,
                input.CategoryId);

            await _postRepository.InsertAsync(post);
            
            return ObjectMapper.Map<Post, PostDto>(post);
        }

        //[Authorize(BlogPermissions.Posts.Edit)]
        public async Task UpdateAsync(Guid id, CreateUpdatePostDto input)
        {
            var post = await _postRepository.GetAsync(id);

            post.Title = input.Title;
            post.Author = input.Author;
            post.Url = input.Url;
            post.Html = input.Html;
            post.Avatar = input.Avatar;
            post.Markdown = input.Markdown;
            post.CategoryId = input.CategoryId;

            await _postRepository.UpdateAsync(post);
        }

        //[Authorize(BlogPermissions.Posts.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}
