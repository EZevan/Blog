using System;
using Volo.Abp.Application.Dtos;

namespace Evans.Blog.Dto
{
    public class CategoryDto : AuditedEntityDto<Guid>
    {
        public string CategoryName { get; set; }

        public string DisplayName { get; set; }
    }
}
