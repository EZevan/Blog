using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Blogs
{
    public class Post : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Url { get; set; }

        public string Html { get; set; }
        
        public string Avatar { get; set; }

        public string Markdown { get; set; }

        public Guid CategoryId { get; set; }
    }
}
