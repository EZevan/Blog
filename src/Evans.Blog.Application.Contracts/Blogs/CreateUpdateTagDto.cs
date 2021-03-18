using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evans.Blog.Blogs
{
    public class CreateUpdateTagDto
    {
        [Required]
        public PostTags TagType { get; set; }

        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }
    }
}
