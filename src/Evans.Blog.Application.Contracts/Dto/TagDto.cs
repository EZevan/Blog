using System;
using Evans.Blog.Enums;
using Volo.Abp.Application.Dtos;

namespace Evans.Blog.Dto
{
    public class TagDto : AuditedEntityDto<Guid>
    {
        public PostTags TagType { get; set; }

        public string DisplayName { get; set; }
    }
}
