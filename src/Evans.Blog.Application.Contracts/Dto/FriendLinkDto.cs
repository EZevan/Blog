using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Dto
{
    public class FriendLinkDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string LinkUrl { get; set; }
    }
}
