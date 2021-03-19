using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Evans.Blog.Services
{
    public class BlogDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Post, Guid> _postRepository;
        private readonly IGuidGenerator _guidGenerator;

        public BlogDataSeedContributor(IRepository<Post,Guid> postRepository, IGuidGenerator guidGenerator)
        {
            _postRepository = postRepository;
            _guidGenerator = guidGenerator;
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
                        Markdown = "It's good to have some initial data in the database before running the application. This section introduces the Data Seeding system of the ABP framework. You can skip this section if you don't want to create seed data, but it is suggested to follow it to learn this useful ABP Framework feature."
                    },
                    autoSave:true
                );
            }
        }
    }
}
