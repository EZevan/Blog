using System;
using System.ComponentModel.DataAnnotations;

namespace Evans.Blog.Dto
{
    public class CreateUpdatePostTagDto
    {
        [Required]
        public Guid PostId { get; set; }

        public Guid TagId { get; set; }
    }
}
