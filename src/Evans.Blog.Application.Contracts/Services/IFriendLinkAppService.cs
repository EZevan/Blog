using System;
using System.Collections.Generic;
using System.Text;
using Evans.Blog.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Evans.Blog.Services
{
    public interface IFriendLinkAppService : 
        ICrudAppService<
            FriendLinkDto, //Used to show Friend links
            Guid, //The primary key of FriendLink entity
            PagedAndSortedResultRequestDto, //Used for paging and sorting
            CreateUpdateFriendLinkDto> //used to create/update friend links
    {
    }
}
