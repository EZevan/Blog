using Evans.Blog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Evans.Blog
{
    [DependsOn(
        typeof(BlogEntityFrameworkCoreTestModule)
        )]
    public class BlogDomainTestModule : AbpModule
    {

    }
}