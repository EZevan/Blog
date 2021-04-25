using System;
using Evans.Blog.Enums;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.CategoryTags
{
    public class Tag : FullAuditedEntity<Guid>
    {
        public string TagType { get; set; }

        public string DisplayName { get; set; }
    }
}
