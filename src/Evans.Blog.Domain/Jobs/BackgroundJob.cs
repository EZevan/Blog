using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.Jobs
{
    public class BackgroundJob : FullAuditedEntity<Guid>
    {
        public string  AppId { get; set; }
        
        public string CallbackUrl { get; set; }
        
        public string CronExpress { get; set; }
        
        public string DataID { get; set; }
        
        public int ExecutionTimeout { get; set; }
        
        public int ExecutionCount { get; set; }
        
        public string HttpHeaders { get; set; }
        
        public string HttpMethod { get; set; }

        public string JobCode { get; set; }
        
        public string JobName { get; set; }
        
        public string JobContext { get; set; }
        
        public int Periodic { get; set; }
        
        public string Protocol { get; set; }
        
        public string QueueName { get; set; }
        
        public string Status { get; set; }
        appId: "screening-web"
        callbackUrl: "http://screening-web/message/msgNoPerfect"
        createBy: null
        createTime: "2020-07-06 09:41:53"
        cronExpression: "0 0 1 * * ?"
        dataId: null
        executeTimeout: 1800
        executionCount: 255
        httpHeaders: null
        httpMethod: null
        id: "8a8380ad724fddde017321c9631f3602"
        isDeleted: 0
        jobCode: "createMessageWarnJob"
        jobContext: null
        jobName: "生成受试者信息未完善提醒"
        periodic: 1
        protocol: "RIBBON"
        queueName: null
        splitByTenant: null
        status: "SUCCESS"
    }
}