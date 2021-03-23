using System.Threading.Tasks;

namespace Evans.Blog.Services
{
    /// <summary>
    /// Hello abp interface corresponding service
    /// </summary>
    public interface IHelloAbpAppService
    {
        string GetAsync(string message);
    }
}