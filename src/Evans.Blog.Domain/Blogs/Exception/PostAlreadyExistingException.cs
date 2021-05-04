using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Evans.Blog.Blogs.Exception
{
    public class PostAlreadyExistingException : BusinessException
    {
        public PostAlreadyExistingException(string title,string author,string content) 
            : base(BlogDomainErrorCodes.PostAlreadyExists)
        {
            WithData(nameof(title), title)
                .WithData(nameof(author), author)
                .WithData(nameof(content), content);
        }
    }
}
