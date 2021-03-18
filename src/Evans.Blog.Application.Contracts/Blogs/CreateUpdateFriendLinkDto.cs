using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evans.Blog.Blogs
{
    public class CreateUpdateFriendLinkDto
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string LinkUrl { get; set; }
    }
}
