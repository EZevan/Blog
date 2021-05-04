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
    /// Category corresponding service
    /// </summary>
    public interface ICategoryAppService : IApplicationService
    {
        Task<ServiceResult<CategoryDto>> GetAsync(Guid id);

        Task<ServiceResult<PagedResultDto<CategoryDto>>> GetListAsync(GetCategoryListDto input);

        Task<ServiceResult<IEnumerable<GetCategoryDto>>> GetListWithoutPaginationAsync(GetCategoryListDto input);

        Task<ServiceResult<CategoryDto>> CreateAsync(CreateUpdateCategoryDto input);

        Task<ServiceResult<string>> UpdateAsync(Guid id, CreateUpdateCategoryDto input);

        Task<ServiceResult<string>> DeleteAsync(Guid id);
    }
}
