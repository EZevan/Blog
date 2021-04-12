using System;
using System.Threading.Tasks;
using Evans.Blog.Blogs;
using Evans.Blog.Blogs.DomainServices;
using Evans.Blog.Blogs.Repositories;
using Evans.Blog.CategoryTags.DomainServices;
using Evans.Blog.CategoryTags.Repositories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Evans.Blog
{
    public class BlogDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IPostRepository _postRepository;
        private readonly PostManager _postManager;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryManager _categoryManager;

        public BlogDataSeedContributor(
            IPostRepository postRepository, 
            PostManager postManager,
            IGuidGenerator guidGenerator,
            ICategoryRepository categoryRepository,
            CategoryManager categoryManager)
        {
            _postRepository = postRepository;
            _postManager = postManager;
            _guidGenerator = guidGenerator;
            _categoryRepository = categoryRepository;
            _categoryManager = categoryManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _postRepository.GetCountAsync() <= 0)
            {
                await _postRepository.InsertAsync(
                    await _postManager.CreatePostAsync(
                        "The first post",
                        "evan",
                        "www.baidu.com",
                        "http://www.baidu.com",
                        "pic/tianwen01.jpg",
                        "It's good to have some initial data in the database before running the application. This section introduces the Data Seeding system of the ABP framework. You can skip this section if you don't want to create seed data, but it is suggested to follow it to learn this useful ABP Framework feature.",
                        _guidGenerator.Create()
                    ),
                    true
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
