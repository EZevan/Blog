using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Blogs
{
    public class Post : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Url { get; set; }

        public string Html { get; set; }
        
        public string Avatar { get; set; }

        public string Markdown { get; set; }

        public Guid CategoryId { get; set; }

        private Post()
        {
            /*
             * This constructor is for deserialization / ORM purpose
             */
        }

        internal Post(
            Guid id,
            [NotNull] string title,
            string author,
            string url,
            string html,
            string avatar,
            string markdown,
            Guid categoryId) : base(id)
        {
            Title = title;
            Author = author;
            Url = url;
            Html = html;
            Avatar = avatar;
            Markdown = markdown;
            CategoryId = categoryId;
        }
    }
}
