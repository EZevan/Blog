using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evans.Blog.CategoryTags.Repositories;
using Evans.Blog.Dto;
using Evans.Blog.JobItems;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace Evans.Blog.BackgroundJobs.JobWorkers
{
    public class HangfireTestQueueJob : AsyncBackgroundJob<HangfireTestJobItem>
    {
        private readonly PeriodicBackgroundWorkerContext _context;

        public HangfireTestQueueJob(PeriodicBackgroundWorkerContext context)
        {
            _context = context;
        }

        public override async Task ExecuteAsync(HangfireTestJobItem args)
        {
            var categoryRep = _context.ServiceProvider.GetService<ICategoryRepository>();
            var list = await categoryRep.GetListAsync();
            var result = JsonConvert.SerializeObject(list);

            RecurringJob.AddOrUpdate( () => Console.WriteLine(result), "*/1 * * * *");
        }
    }
}
