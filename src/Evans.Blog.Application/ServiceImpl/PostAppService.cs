using System;
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
    public class PostAppService :
        CrudAppService<
            Post,
            PostDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdatePostDto>,
        IPostAppService
    {
        public PostAppService(IRepository<Post, Guid> repository) : base(repository)
        {
        }
    }
}
