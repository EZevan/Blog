using System;
using Evans.Blog.Enums;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Services
{
    public class Tag : FullAuditedEntity<Guid>
    {
        public PostTags TagType { get; set; }

        public string DisplayName { get; set; }
    }
}
