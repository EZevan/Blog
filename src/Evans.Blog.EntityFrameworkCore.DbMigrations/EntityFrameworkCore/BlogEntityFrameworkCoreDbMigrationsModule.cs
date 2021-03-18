using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Evans.Blog.EntityFrameworkCore
{
    [DependsOn(
        typeof(BlogEntityFrameworkCoreModule)
        )]
    public class BlogEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BlogMigrationsDbContext>();
        }
    }
}
