using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<CategoryDto> GetAsync(Guid id);

        Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListDto input);

        Task<IEnumerable<GetCategoryDto>> GetListWithoutPaginationAsync(GetCategoryListDto input);

        Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input);

        Task UpdateAsync(Guid id, CreateUpdateCategoryDto input);

        Task DeleteAsync(Guid id);
    }
}
