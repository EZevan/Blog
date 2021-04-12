using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evans.Blog.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Evans.Blog.Services
{
    /// <summary>
    /// Post corresponding service
    /// </summary>
    public interface IPostAppService : IApplicationService
    {
        Task<PostDto> GetAsync(Guid id);

        Task<PagedResultDto<PostDto>> GetListAsync(GetPostListDto input);

        Task<PostDto> CreateAsync(CreateUpdatePostDto input);

        Task UpdateAsync(Guid id, CreateUpdatePostDto input);

        Task DeleteAsync(Guid id);
    }
}
