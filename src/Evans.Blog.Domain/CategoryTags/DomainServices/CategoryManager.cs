using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evans.Blog.CategoryTags.Exception;
using Evans.Blog.CategoryTags.Repositories;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Evans.Blog.CategoryTags.DomainServices
{
    public class CategoryManager : DomainService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateCategoryAsync([NotNull] string name, string displayName)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingCategory = await _categoryRepository.FindByNameAsync(name);
            if (existingCategory != null)
            {
                throw new CategoryAlreadyExistsException(name);
            }

            return new Category(GuidGenerator.Create(), name, displayName);
        }

        public async Task ChangeNameAsync([NotNull] Category category, [NotNull] string newName)
        {
            Check.NotNull(category, nameof(category));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingCategory = await _categoryRepository.FindByNameAsync(newName);
            if (existingCategory != null && existingCategory.Id != category.Id)
            {
                throw new CategoryAlreadyExistsException(newName);
            }

            category.ChangeName(newName);
        }
    }
}
