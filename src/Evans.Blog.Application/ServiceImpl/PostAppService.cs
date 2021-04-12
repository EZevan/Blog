﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evans.Blog.Blogs;
using Evans.Blog.Blogs.DomainServices;
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
    //[Authorize(BlogPermissions.Posts.Default)]
    public class PostAppService : BlogAppService, IPostAppService
    {
        private readonly IPostRepository _postRepository;
        private readonly PostManager _postManager;

        public PostAppService(
            IPostRepository postRepository,
            PostManager postManager)
        {
            _postRepository = postRepository;
            _postManager = postManager;
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
