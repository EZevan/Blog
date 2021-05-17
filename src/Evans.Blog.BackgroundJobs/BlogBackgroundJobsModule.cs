using System;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Modularity;

namespace Evans.Blog.BackgroundJobs
{
    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    public class BlogBackgroundJobsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
        
        
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var configuration = context.GetConfiguration();

            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                // Queue name
                //options.Queues = new[] {"test1", "test2"};
                // Wait for all jobs performed when background server shutdown.
                ShutdownTimeout = TimeSpan.FromMinutes(30),
                // Concurrent job counts, default is 20.
                WorkerCount = Math.Max(Environment.ProcessorCount, 20)
            });
            
            app.UseHangfireDashboard(options:new DashboardOptions{
                //AppPath = configuration[""],
                DashboardTitle = "Job Schedule Center",
                Authorization = new[]
                {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        RequireSsl = false,
                        SslRedirect = false,
                        LoginCaseSensitive = true,
                        Users = new[]
                        {
                            new BasicAuthAuthorizationUser
                            {
                                Login = configuration["HangfireAuth:Login"],
                                PasswordClear = configuration["HangfireAuth:Password"]
                            }
                        }
                    })
                }});
        }
    }
}
