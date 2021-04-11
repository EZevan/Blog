using System;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.CategoryTags.Repositories
{
    public interface ITagRepository : IRepository<Tag,Guid>
    {
    }
}
