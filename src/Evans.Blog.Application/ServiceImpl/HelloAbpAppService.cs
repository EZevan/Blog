using System;
using System.Threading.Tasks;
using Evans.Blog.Services;
using IdentityServer4.Extensions;

namespace Evans.Blog.ServiceImpl
{
    /// <summary>
    /// Hello abp corresponding service
    /// </summary>
    public class HelloAbpAppService : BlogAppService,IHelloAbpAppService
    {
        /// <summary>
        /// Get method
        /// </summary>
        /// <param name="message">message parameter</param>
        /// <returns></returns>
        public string GetAsync(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message),"parameter cannot be null");
            }

            return message;
        }
    }
}