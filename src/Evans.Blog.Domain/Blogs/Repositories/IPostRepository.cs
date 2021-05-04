using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.Blogs.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<Post> FindByTitleAuthorContentAsync(string title,string author,string content);

        Task<List<Post>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
            );
    }
}