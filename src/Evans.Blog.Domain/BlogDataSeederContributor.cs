using System;
using System.Threading.Tasks;
using Evans.Blog.CategoryTags.DomainServices;
using Evans.Blog.CategoryTags.Repositories;
using Evans.Blog.Services;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Evans.Blog
{
    public class BlogDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Post, Guid> _postRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryManager _categoryManager;

        public BlogDataSeedContributor(
            IRepository<Post,Guid> postRepository, 
            IGuidGenerator guidGenerator,
            ICategoryRepository categoryRepository,
            CategoryManager categoryManager)
        {
            _postRepository = postRepository;
            _guidGenerator = guidGenerator;
            _categoryRepository = categoryRepository;
            _categoryManager = categoryManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _postRepository.GetCountAsync() <= 0)
            {
                await _postRepository.InsertAsync(
                    new Post
                    {
                        Title = "The first post",
                        Author = "evan",
                        CategoryId = _guidGenerator.Create(),
                        Url = "www.baidu.com",
                        Html = "http://www.baidu.com",
                        Avatar = "pic/tianwen01.jpg",
                        Markdown = "It's good to have some initial data in the database before running the application. This section introduces the Data Seeding system of the ABP framework. You can skip this section if you don't want to create seed data, but it is suggested to follow it to learn this useful ABP Framework feature."
                    },
                    autoSave:true
                );
            }


            // Added seed data for categories

            if (await _categoryRepository.GetCountAsync() <= 0)
            {
                await _categoryRepository.InsertAsync(
                    await _categoryManager.CreateCategoryAsync(
                        ".Net", "Microsoft dot net"));

                await _categoryRepository.InsertAsync(
                    await _categoryManager.CreateCategoryAsync(
                        "Java", "Oracle java"));

                await _categoryRepository.InsertAsync(
                    await _categoryManager.CreateCategoryAsync(
                        "Python", "Python"));

                await _categoryRepository.InsertAsync(
                    await _categoryManager.CreateCategoryAsync(
                        "SQLServer", "Microsoft SQL database"));

                await _categoryRepository.InsertAsync(
                    await _categoryManager.CreateCategoryAsync(
                        "MySQL", "MySQL database"));

                await _categoryRepository.InsertAsync(
                    await _categoryManager.CreateCategoryAsync(
                        "DevOps", "DevOps"));
            }
        }
    }
}
