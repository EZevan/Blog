using System;
using Evans.Blog.Dto;
using Evans.Blog.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.ServiceImpl
{
    public class PostTagAppService :
        CrudAppService<
            PostTag,
            PostTagDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdatePostTagDto>,
        IPostTagAppService
    {
        public PostTagAppService(IRepository<PostTag, Guid> repository) : base(repository)
        {
        }
    }
}
