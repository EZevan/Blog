using System;
using Evans.Blog.Services;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Evans.Blog.EntityFrameworkCore
{
    public static class BlogDbContextModelCreatingExtensions
    {
        public static void ConfigureBlog(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BlogConsts.DbTablePrefix + "YourEntities", BlogConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<Post>(b =>
            {
                b.ToTable(BlogConsts.DbTablePrefix + BlogConsts.DbTableNamePost);
                b.ConfigureByConvention();
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).HasMaxLength(255).IsRequired().HasComment("The title of blog");
                b.Property(x => x.Author).HasMaxLength(50).HasComment("The author of blog");
                b.Property(x => x.Url).HasMaxLength(255).IsRequired().HasComment("The url of blog");
                b.Property(x => x.Html).HasColumnType("longtext").IsRequired().HasComment("The html of blog");
                b.Property(x => x.Avatar).HasColumnType("longtext").HasComment("The avatar of blog");
                b.Property(x => x.Markdown).HasColumnType("longtext").IsRequired().HasComment("The markdown of blog");
                b.Property(x => x.CategoryId).HasComment("The category id of blog");
            })
                .AddCommentForFullAuditedAggregateRootProps<Post>();

            builder.Entity<Category>(b =>
            {
                b.ToTable(BlogConsts.DbTablePrefix + BlogConsts.DbTableNameCategory).HasComment("The category of blog.");
                b.ConfigureByConvention();
                b.HasKey(x => x.Id);
                b.Property(x => x.CategoryName).HasMaxLength(50).IsRequired().HasComment("The category name of blog");
                b.Property(x => x.DisplayName).HasMaxLength(50).IsRequired().HasComment("The display name of category");
            })
                .AddCommentForFullAuditedEntityProps<Category>();

            builder.Entity<Tag>(b =>
            {
                b.ToTable(BlogConsts.DbTablePrefix + BlogConsts.DbTableNameTag).HasComment("The tag of blog.");
                b.ConfigureByConvention();
                b.HasKey(x => x.Id);
                b.Property(x => x.TagType).HasMaxLength(50).IsRequired().HasComment("the tag name");
                b.Property(x => x.DisplayName).HasMaxLength(50).IsRequired().HasComment("The display name of tag");
            })
                .AddCommentForFullAuditedEntityProps<Tag>();

            builder.Entity<PostTag>(b =>
            {
                b.ToTable(BlogConsts.DbTablePrefix + BlogConsts.DbTableNamePostTag).HasComment("The post tab of blog.");
                b.ConfigureByConvention();
                b.HasKey(x => x.Id);
                b.Property(x => x.PostId).IsRequired().HasComment("the post id of blog");
                b.Property(x => x.TagId).IsRequired().HasComment("the tag id of blog");
            })
                .AddCommentForFullAuditedEntityProps<PostTag>();

            builder.Entity<FriendLink>(b =>
            {
                b.ToTable(BlogConsts.DbTablePrefix + BlogConsts.DbTableNameFriendLink).HasComment("The friend link of blog.");
                b.ConfigureByConvention();
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).HasMaxLength(50).IsRequired().HasComment("The title of friend link");
                b.Property(x => x.LinkUrl).HasMaxLength(255).IsRequired().HasComment("The link url of friend link");
            })
                .AddCommentForFullAuditedEntityProps<FriendLink>();
        }

        private static ModelBuilder AddCommentForFullAuditedAggregateRootProps<TEntity>(this ModelBuilder builder) where TEntity : FullAuditedAggregateRoot<Guid>
        {
            return builder.Entity<TEntity>(b =>
            {
                b.Property(x => x.Id).HasComment("The Primary key");
                b.Property(x => x.CreatorId).HasComment("The id of creator");
                b.Property(x => x.CreationTime).HasComment("The creation time");
                b.Property(x => x.LastModifierId).HasComment("The id of last modifier");
                b.Property(x => x.LastModificationTime).HasComment("The last modification time");
                b.Property(x => x.DeleterId).HasComment("The id of deleter");
                b.Property(x => x.DeletionTime).HasComment("The deletion time");
                b.Property(x => x.IsDeleted).HasComment("The flag of deletion：0 not deleted，1 deleted");
            });
        }

        private static ModelBuilder AddCommentForFullAuditedEntityProps<TEntity>(this ModelBuilder builder) where TEntity : FullAuditedEntity<Guid>
        {
            return builder.Entity<TEntity>(b =>
            {
                b.Property(x => x.Id).HasComment("The Primary key");
                b.Property(x => x.CreatorId).HasComment("The id of creator");
                b.Property(x => x.CreationTime).HasComment("The creation time");
                b.Property(x => x.LastModifierId).HasComment("The id of last modifier");
                b.Property(x => x.LastModificationTime).HasComment("The last modification time");
                b.Property(x => x.DeleterId).HasComment("The id of deleter");
                b.Property(x => x.DeletionTime).HasComment("The deletion time");
                b.Property(x => x.IsDeleted).HasComment("The flag of deletion：0 not deleted，1 deleted");
            });
        }
    }
}