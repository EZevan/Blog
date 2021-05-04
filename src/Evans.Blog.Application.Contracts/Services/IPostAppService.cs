using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evans.Blog.Domain.Shared.Dto;
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
        Task<ServiceResult<PostDto>> GetAsync(Guid id);

        Task<ServiceResult<PagedResultDto<PostDto>>> GetListAsync(GetPostListDto input);

        Task<ServiceResult<PostDto>> CreateAsync(CreateUpdatePostDto input);

        Task<ServiceResult<string>> UpdateAsync(Guid id, CreateUpdatePostDto input);

        Task<ServiceResult<string>> DeleteAsync(Guid id);
    }
}
