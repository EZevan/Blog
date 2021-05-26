using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Jobs
{
    public class BackgroundJob : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Application Id
        /// </summary>
        public string  AppId { get; set; }
        
        /// <summary>
        /// Job execution url
        /// </summary>
        public string CallbackUrl { get; set; }
        
        /// <summary>
        /// Job execution cron expression
        /// </summary>
        public string CronExpress { get; set; }
        
        /// <summary>
        /// The relevant data id of job, such as certain testCaseId
        /// </summary>
        public string DataId { get; set; }
        
        /// <summary>
        /// Job execution timeout
        /// </summary>
        public int ExecutionTimeout { get; set; }
        
        /// <summary>
        /// Job executed counts
        /// </summary>
        public int ExecutionCount { get; set; }
        
        /// <summary>
        /// Http request header
        /// </summary>
        public string HttpHeaders { get; set; }
        
        /// <summary>
        /// Http request method
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Job code
        /// </summary>
        public string JobCode { get; set; }
        
        /// <summary>
        /// Job name
        /// </summary>
        public string JobName { get; set; }
        
        /// <summary>
        /// Job arguments
        /// </summary>
        public string JobContext { get; set; }
        
        /// <summary>
        /// Whether the job is periodic or not
        /// </summary>
        public int Periodic { get; set; }

        /// <summary>
        /// Job execution protocol
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Queue name
        /// </summary>
        public string QueueName { get; set; }
        
        /// <summary>
        /// Job execution statuis
        /// </summary>
        public string Status { get; set; }
    }
}