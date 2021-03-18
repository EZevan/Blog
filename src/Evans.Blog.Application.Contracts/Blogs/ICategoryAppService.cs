using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Evans.Blog.Blogs
{
    public interface ICategoryAppService : 
        ICrudAppService<
            CategoryDto, //Used to show categories
            Guid, //Primary key of category entity
            PagedAndSortedResultRequestDto, //Used for paging and sorting 
            CreateUpdateCategoryDto> //Used to create/update categories
    {
    }
}
