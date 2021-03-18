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
    public class CategoryAppService :
        CrudAppService<
            Category,
            CategoryDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCategoryDto>,
        ICategoryAppService
    {
        public CategoryAppService(IRepository<Category, Guid> repository) : base(repository)
        {
        }
    }
}
