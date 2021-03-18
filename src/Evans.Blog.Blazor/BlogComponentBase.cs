using Evans.Blog.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Evans.Blog.Blazor
{
    public abstract class BlogComponentBase : AbpComponentBase
    {
        protected BlogComponentBase()
        {
            LocalizationResource = typeof(BlogResource);
        }
    }
}
