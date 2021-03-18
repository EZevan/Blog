using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Evans.Blog
{
    [Dependency(ReplaceServices = true)]
    public class BlogBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Blog";
    }
}
