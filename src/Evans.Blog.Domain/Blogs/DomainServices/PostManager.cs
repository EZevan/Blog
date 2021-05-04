using System;
using System.Threading.Tasks;
using Evans.Blog.Blogs.Exception;
using Evans.Blog.Blogs.Repositories;
using Evans.Blog.CategoryTags.Exception;
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

            var existingPost = await _postRepository.FindByTitleAuthorContentAsync(title, author, markdown);
            if (existingPost != null)
            {
                throw new PostAlreadyExistingException(title,author,markdown);
            }

            return new Post(
                GuidGenerator.Create(), title, author, url, html, avatar, markdown, categoryId);
        }
    }
}