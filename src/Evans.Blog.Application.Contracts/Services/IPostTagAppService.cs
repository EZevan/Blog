using System;
using Evans.Blog.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Evans.Blog.Services
{
    public interface IPostTagAppService: 
        ICrudAppService<
            PostTagDto, //Used to show post tags
            Guid, //Primary key of post tag entity
            PagedAndSortedResultRequestDto, //Used for paging and sorting 
            CreateUpdatePostTagDto> //Used to create/update post tag
    {
    }
}
