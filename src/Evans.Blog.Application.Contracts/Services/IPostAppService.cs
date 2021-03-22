using System;
using Evans.Blog.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Evans.Blog.Services
{
    /// <summary>
    /// The post 
    /// </summary>
    public interface IPostAppService : 
        ICrudAppService<
            PostDto, //Used to show posts
            Guid, //Primary key of post entity
            PagedAndSortedResultRequestDto, //Used for paging and sorting
            CreateUpdatePostDto> //used to create/update posts
    {
    }
}
