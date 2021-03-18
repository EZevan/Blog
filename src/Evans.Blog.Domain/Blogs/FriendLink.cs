using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Blogs
{
    public class FriendLink : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }

        public string LinkUrl { get; set; }
    }
}
