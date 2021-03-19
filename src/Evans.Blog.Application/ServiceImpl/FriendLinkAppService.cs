using System;
using Evans.Blog.Dto;
using Evans.Blog.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.ServiceImpl
{
    public class FriendLinkAppService : 
        CrudAppService<
            FriendLink,
            FriendLinkDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateFriendLinkDto>,
        IFriendLinkAppService
    {
        public FriendLinkAppService(IRepository<FriendLink, Guid> repository) : base(repository)
        {
        }
    }
}
