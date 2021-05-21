using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.BackgroundJobs;

namespace Evans.Blog.JobItems
{
    [BackgroundJobName(nameof(HangfireTestJobItem))]
    public class HangfireTestJobItem
    {
        public string JobCode { get; set; }

        public string JobDescription { get; set; }

        public string CronExpression { get; set; }
    }
}
