using System;
using System.ComponentModel.DataAnnotations;

namespace Evans.Blog.Dto
{
    public class CreateUpdatePostDto
    {
        /// <summary>
        /// Post title
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Post author
        /// </summary>
        [StringLength(50)]
        public string Author { get; set; }

        /// <summary>
        /// Post url
        /// </summary>
        [Required]
        [StringLength(255)]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        /// <summary>
        /// Post html
        /// </summary>
        [Required]
        [StringLength(255)]
        [DataType(DataType.Html)]
        public string Html { get; set; }
        
        /// <summary>
        /// Post avatar
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Post content
        /// </summary>
        [Required]
        public string Markdown { get; set; }

        /// <summary>
        /// Category id
        /// </summary>
        public Guid CategoryId { get; set; }
    }
}
