using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Evans.Blog.Blogs.Repositories;
using Evans.Blog.CategoryTags;
using Evans.Blog.CategoryTags.DomainServices;
using Evans.Blog.CategoryTags.Repositories;
using Evans.Blog.Dto;
using Evans.Blog.Permissions;
using Evans.Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Evans.Blog.ServiceImpl
{
    /// <summary>
    /// Category corresponding service
    /// </summary>
    //[Authorize(BlogPermissions.Categories.Default)]
    public class CategoryAppService : BlogAppService, ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryManager _categoryManager;
        private readonly IPostRepository _postRepository;

        public CategoryAppService(
            ICategoryRepository categoryRepository,
            CategoryManager categoryManager,
            IPostRepository postRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryManager = categoryManager;
            _postRepository = postRepository;
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return ObjectMapper.Map<Category, CategoryDto>(category);
        }
        
        public async Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListDto input)
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

        //[ActionName(nameof(GetListWithoutPaginationAsync))]
        //[Route("[controller]/[action]")]
        public async Task<IEnumerable<GetCategoryDto>> GetListWithoutPaginationAsync(GetCategoryListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Category.CategoryName);
            }

            
            var queryable = await _categoryRepository.GetQueryableAsync();

            var queryResults =
                from category in queryable
                join post in _postRepository
                on category.Id equals post.CategoryId into temp
                from t in temp.DefaultIfEmpty()
                group category by new
                {
                    category.CategoryName,
                    category.DisplayName,
                    category.CreationTime,
                    category.Id,
                    t.CategoryId
                }
                into g
                select new GetCategoryDto
                {
                    Id = g.Key.Id,
                    CategoryName = g.Key.CategoryName,
                    DisplayName = g.Key.DisplayName,
                    CreationTime = g.Key.CreationTime,
                    Count = g.Key.Id.ToString() != g.Key.CategoryId.ToString() ? 0 : g.Count()
                };

            var results = queryResults
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(),
                    c => c.CategoryName.Contains(input.Filter) || c.DisplayName.Contains(input.Filter))
                .OrderBy(input.Sorting)
                // .Skip(input.SkipCount)
                // .Take(input.MaxResultCount)
                .ToList();
            
            return results;
        }

        //[Authorize(BlogPermissions.Categories.Create)]
        public async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            var category = await _categoryManager.CreateCategoryAsync(
                input.CategoryName, 
                input.DisplayName);

            await _categoryRepository.InsertAsync(category);

            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        [Authorize(BlogPermissions.Categories.Edit)]
        public async Task UpdateAsync(Guid id, CreateUpdateCategoryDto input)
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
        public async Task DeleteAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}
