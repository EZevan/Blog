using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Evans.Blog.Blogs
{
    public class CategoryDto : AuditedEntityDto<Guid>
    {
        public string CategoryName { get; set; }

        public string DisplayName { get; set; }
    }
}
