using System;
using Evans.Blog.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Evans.Blog.Services
{
    /// <summary>
    /// Category corresponding service
    /// </summary>
    public interface ICategoryAppService : 
        ICrudAppService<
            CategoryDto, //Used to show categories
            Guid, //Primary key of category entity
            PagedAndSortedResultRequestDto, //Used for paging and sorting 
            CreateUpdateCategoryDto> //Used to create/update categories
    {
    }
}
