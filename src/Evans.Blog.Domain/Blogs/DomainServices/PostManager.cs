using System;
using System.Threading.Tasks;
using Evans.Blog.Blogs.Repositories;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Evans.Blog.Blogs.DomainServices
{
    public class PostManager : DomainService
    {
        private readonly IPostRepository _postRepository;

        public PostManager(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        public async Task<Post> CreatePostAsync(string title, string author, string url, string html, string avatar, string markdown,
            Guid categoryId)
        {
            Check.NotNullOrWhiteSpace(title,nameof(title));

            return new Post(
                GuidGenerator.Create(), title, author, url, html, avatar, markdown, categoryId);
        }
    }
}