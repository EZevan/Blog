using AutoMapper;
using Evans.Blog.Blogs;
using Evans.Blog.CategoryTags;
using Evans.Blog.Dto;
using Evans.Blog.Services;

namespace Evans.Blog
{
    public class BlogApplicationAutoMapperProfile : Profile
    {
        public BlogApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Post, PostDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Tag, TagDto>();
            CreateMap<PostTag, PostTagDto>();
            CreateMap<FriendLink, FriendLinkDto>();

            CreateMap<CreateUpdatePostDto, Post>();
            CreateMap<CreateUpdateCategoryDto, Category>();
            CreateMap<CreateUpdateTagDto, Tag>();
            CreateMap<CreateUpdatePostTagDto, PostTag>();
            CreateMap<CreateUpdateFriendLinkDto, FriendLink>();
        }
    }
}
