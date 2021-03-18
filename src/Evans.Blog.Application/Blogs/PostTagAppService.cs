using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.Blogs
{
    public class PostTagAppService :
        CrudAppService<
            PostTag,
            PostTagDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdatePostTagDto>,
        IPostTagAppService
    {
        public PostTagAppService(IRepository<PostTag, Guid> repository) : base(repository)
        {
        }
    }
}
