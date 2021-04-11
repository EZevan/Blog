using System;
using Evans.Blog.CategoryTags;
using Evans.Blog.Dto;
using Evans.Blog.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.ServiceImpl
{
    public class TagAppService : 
        CrudAppService<
            Tag,
            TagDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateTagDto>,
        ITagAppService
    {
        public TagAppService(IRepository<Tag, Guid> repository) : base(repository)
        {
        }
    }
}
