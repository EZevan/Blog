using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evans.Blog.Blogs;
using Evans.Blog.Blogs.Repositories;
using Evans.Blog.Dto;
using Evans.Blog.Permissions;
using Evans.Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.ServiceImpl
{
    [Authorize(BlogPermissions.Posts.Default)]
    public class PostAppService : BlogAppService, IPostAppService
    {
        private readonly IPostRepository _postRepository;

        public PostAppService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<PostDto> GetAsync(Guid id)
        {
            var post = await _postRepository.GetAsync(id);
            return ObjectMapper.Map<Post, PostDto>(post);
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

            var totalCount = input.Filter.IsNullOrWhiteSpace()
                ? await _postRepository.CountAsync()
                : await _postRepository.CountAsync(post =>
                    post.Title.Contains(input.Filter) || post.Markdown.Contains(input.Filter));

            return new PagedResultDto<PostDto>(
                totalCount, 
                ObjectMapper.Map<List<Post>,List<PostDto>>(posts));
        }

        public Task<PostDto> CreateAsync(CreateUpdatePostDto input)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, CreateUpdatePostDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
