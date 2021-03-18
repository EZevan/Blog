using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace Evans.Blog.Blogs
{
    public class CreateUpdatePostTagDto
    {
        [Required]
        public Guid PostId { get; set; }

        public Guid TagId { get; set; }
    }
}
