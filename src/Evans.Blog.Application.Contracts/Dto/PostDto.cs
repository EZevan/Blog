using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Evans.Blog.Dto
{
    public class PostDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// Post title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Post author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Post url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Post html
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// Post avatar
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Post content
        /// </summary>
        public string Markdown { get; set; }
        
        /// <summary>
        /// Category name
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Category id
        /// </summary>
        public Guid CategoryId { get; set; }
    }
}
