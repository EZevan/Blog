using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Evans.Blog.CategoryTags.Exception
{
    public class CategoryAlreadyExistsException : BusinessException
    {
        public CategoryAlreadyExistsException(string name) 
            : base(BlogDomainErrorCodes.CategoryAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
