using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Evans.Blog.Blogs;
using Evans.Blog.Blogs.Repositories;
using Evans.Blog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Evans.Blog.Repositories
{
    public class PostRepository : EfCoreRepository<BlogDbContext,Post,Guid>, IPostRepository 
    {
        public PostRepository(IDbContextProvider<BlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Post>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), post => post.Title.Contains(filter))
                .WhereIf(!filter.IsNullOrWhiteSpace(), post => post.Markdown.Contains(filter))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
