using System;
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
        Task<CategoryDto> GetCategoryAsync(Guid id);

        Task<PagedResultDto<CategoryDto>> GetCategoryListAsync(GetCategoryListDto input);

        Task<CategoryDto> CreateCategoryAsync(CreateUpdateCategoryDto input);

        Task UpdateCategoryAsync(Guid id, CreateUpdateCategoryDto input);

        Task DeleteCategoryAsync(Guid id);
    }
}
