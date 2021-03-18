using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Blogs
{
    public class PostTag : FullAuditedEntity<Guid>
    {
        public Guid PostId { get; set; }

        public Guid TagId { get; set; }
    }
}
