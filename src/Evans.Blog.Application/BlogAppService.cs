using System;
using System.Collections.Generic;
using System.Text;
using Evans.Blog.Domain.Shared.Dto;
using Evans.Blog.Dto;
using Evans.Blog.Localization;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace Evans.Blog
{
    /* Inherit your application services from this class.
     */
    public abstract class BlogAppService : ApplicationService
    {
        public IDistributedCache<ServiceResult<PostDto>> Cache4PostDto { get; set; }
        public IDistributedCache<ServiceResult<PagedResultDto<PostDto>>> Cache4PagedResultDtoPostDto { get; set; }
        public IDistributedCache<ServiceResult<string>> Cache4String { get; set; }

        protected BlogAppService()
        {
            LocalizationResource = typeof(BlogResource);
        }
    }
}
