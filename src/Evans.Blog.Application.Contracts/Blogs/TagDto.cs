using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Evans.Blog.Blogs
{
    public class TagDto : AuditedEntityDto<Guid>
    {
        public PostTags TagType { get; set; }

        public string DisplayName { get; set; }
    }
}
