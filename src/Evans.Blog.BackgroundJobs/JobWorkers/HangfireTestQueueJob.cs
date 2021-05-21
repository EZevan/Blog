using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evans.Blog.CategoryTags.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace Evans.Blog.BackgroundJobs.JobWorkers
{
    public class HangfireTestQueueJob : AsyncPeriodicBackgroundWorkerBase
    {
        public HangfireTestQueueJob(AbpAsyncTimer timer, IServiceScopeFactory serviceScopeFactory) 
            : base(timer, serviceScopeFactory)
        {
            timer.Period = 60000;
        }

        protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            Logger.LogInformation("Starting: Testing hangfile job!");

            var categoryRepository = workerContext.ServiceProvider.GetService<ICategoryRepository>();

            if(categoryRepository != null)
            {
                var list = await categoryRepository.GetListAsync();
                var result = JsonConvert.SerializeObject(list);
                
                Logger.LogInformation($"Completed: background job,the following is the result of category list:\n{result}");
            }

            Logger.LogError("Fatal: Executing hangfire job failed!");
        }
    }
}
