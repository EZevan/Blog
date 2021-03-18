using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Evans.Blog.Blogs
{
    public interface ITagAppService :
        ICrudAppService<
            TagDto, //Used to show tags
            Guid, //Primary key of tag entity
            PagedAndSortedResultRequestDto, //Used for paging and sorting
            CreateUpdateTagDto> // Used to create/update tags
    {
    }
}
