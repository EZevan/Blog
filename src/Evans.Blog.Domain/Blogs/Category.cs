using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Blogs
{
    public class Category : FullAuditedEntity<Guid>
    {
        public string CategoryName { get; set; }

        public string DisplayName  { get; set; }
    }
}
