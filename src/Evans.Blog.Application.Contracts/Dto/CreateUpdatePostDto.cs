using System;
using System.ComponentModel.DataAnnotations;

namespace Evans.Blog.Dto
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
