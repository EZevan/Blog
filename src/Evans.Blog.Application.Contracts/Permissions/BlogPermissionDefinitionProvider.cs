using Evans.Blog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Evans.Blog.Permissions
{
    public class BlogPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var blogGroup = context.AddGroup(BlogPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BlogPermissions.MyPermission1, L("Permission:MyPermission1"));

            var postsPermission = blogGroup.AddPermission(
                BlogPermissions.Posts.Default, L("Permission:Posts"));

            postsPermission.AddChild(
                BlogPermissions.Posts.Create, L("Permission:Posts.Create"));
            postsPermission.AddChild(
                BlogPermissions.Posts.Edit, L("Permission:Posts.Edit"));
            postsPermission.AddChild(
                BlogPermissions.Posts.Delete, L("Permission:Posts.Delete"));

            var categoriesPermission = blogGroup.AddPermission(
                BlogPermissions.Categories.Default, L("Permission:Categories"));

            categoriesPermission.AddChild(
                BlogPermissions.Categories.Create, L("Permission:Categories.Create"));
            categoriesPermission.AddChild(
                BlogPermissions.Categories.Edit, L("Permission:Categories.Edit"));
            categoriesPermission.AddChild(
                BlogPermissions.Categories.Delete, L("Permission:Categories.Delete"));


        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BlogResource>(name);
        }
    }
}
