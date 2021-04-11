using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Blogs
{
    public class FriendLink : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }

        public string LinkUrl { get; set; }
    }
}
