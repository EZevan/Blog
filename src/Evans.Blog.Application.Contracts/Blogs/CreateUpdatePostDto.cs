using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evans.Blog.Blogs
{
    public class CreateUpdatePostDto
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Html)]
        public string Html { get; set; }

        [Required]
        public string Markdown { get; set; }

        public Guid CategoryId { get; set; }
    }
}
