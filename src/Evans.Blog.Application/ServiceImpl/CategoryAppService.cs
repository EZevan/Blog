using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evans.Blog.CategoryTags;
using Evans.Blog.CategoryTags.DomainServices;
using Evans.Blog.CategoryTags.Repositories;
using Evans.Blog.Dto;
using Evans.Blog.Permissions;
using Evans.Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.ServiceImpl
{
    /// <summary>
    /// Category corresponding service
    /// </summary>
    [Authorize(BlogPermissions.Categories.Default)]
    public class CategoryAppService : BlogAppService, ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryManager _categoryManager;

        public CategoryAppService(
            ICategoryRepository categoryRepository,
            CategoryManager categoryManager)
        {
            _categoryRepository = categoryRepository;
            _categoryManager = categoryManager;
        }

        public async Task<CategoryDto> GetCategoryAsync(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public async Task<PagedResultDto<CategoryDto>> GetCategoryListAsync(GetCategoryListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Category.CategoryName);
            }

            var categories = await _categoryRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter);

            var totalCount = input.Filter == null
                ? await _categoryRepository.CountAsync()
                : await _categoryRepository.CountAsync(category => category.CategoryName.Contains(input.Filter));

            return new PagedResultDto<CategoryDto>(
                totalCount,
                ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories));
        }

        [Authorize(BlogPermissions.Categories.Create)]
        public async Task<CategoryDto> CreateCategoryAsync(CreateUpdateCategoryDto input)
        {
            var category = await _categoryManager.CreateCategoryAsync(
                input.CategoryName, 
                input.DisplayName);

            await _categoryRepository.InsertAsync(category);

            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        [Authorize(BlogPermissions.Categories.Edit)]
        public async Task UpdateCategoryAsync(Guid id, CreateUpdateCategoryDto input)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category.CategoryName != input.CategoryName)
            {
                await _categoryManager.ChangeNameAsync(category, input.CategoryName);
            }

            category.DisplayName = input.CategoryName;

            await _categoryRepository.UpdateAsync(category);
        }

        [Authorize(BlogPermissions.Categories.Delete)]
        public async Task DeleteCategoryAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}
