using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.Blogs.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
            );
    }
}