using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Evans.Blog.Blogs
{
    public class PostDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Url { get; set; }

        public string Html { get; set; }

        public string Markdown { get; set; }

        public Guid CategoryId { get; set; }
    }
}
