using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evans.Blog.Blogs
{
    public class CreateUpdateCategoryDto
    {
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }
    }
}
