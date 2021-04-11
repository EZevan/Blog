using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Blogs
{
    public class PostTag : FullAuditedEntity<Guid>
    {
        public Guid PostId { get; set; }

        public Guid TagId { get; set; }
    }
}
