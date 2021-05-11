using System;
using Hangfire;
using Hangfire.MySql;
using IdentityServer4.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            var configuration = context.Services.GetConfiguration();
            
            ConfigureHangfire(context,configuration);
            
        }

        private void ConfigureHangfire(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddHangfire(config =>
            {
                config.UseStorage(
                    new MySqlStorage(
                        configuration.GetConnectionString("Default"),
                        new MySqlStorageOptions
                        {
                            TablesPrefix = BlogConsts.DbTablePrefix + "hangfire"
                        })
                );
            });
            
            Configure<BackgroundJobServerOptions>(options =>
            {
                // Queue name
                //options.Queues = new[] {"test1", "test2"};
                // Wait for all jobs performed when background server shutdown.
                options.ShutdownTimeout = TimeSpan.FromMinutes(30);
                // Concurrent job counts, default is 20.
                options.WorkerCount = Math.Max(Environment.ProcessorCount, 20);
            });
        }
        
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var configuration = context.GetConfiguration();

            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}
