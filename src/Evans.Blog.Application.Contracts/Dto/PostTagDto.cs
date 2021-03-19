using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Evans.Blog.Dto
{
    public class PostTagDto : AuditedEntityDto<Guid>
    {
        public Guid PostId { get; set; }

        public Guid TagId { get; set; }
    }
}
