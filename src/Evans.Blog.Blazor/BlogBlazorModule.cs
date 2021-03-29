using System;
using System.Net.Http;
using Evans.Blog.Blazor.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.Autofac.WebAssembly;
using Volo.Abp.Modularity;

namespace Evans.Blog.Blazor
{
    [DependsOn(
        typeof(AbpAutofacWebAssemblyModule)
    )]
    public class BlogBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();
            var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
            var configuration = context.Services.GetConfiguration();

            ConfigureUi(builder);
            ConfigureHttpClient(context, environment, configuration);
            ConfigureCommonServices(context);
        }

        /// <summary>
        /// Configures the entry of startup.
        /// </summary>
        /// <param name="builder">The <see cref="WebAssemblyHostBuilder"/> object.</param>
        private void ConfigureUi(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");
        }

        /// <summary>
        /// Registers <see cref="HttpClient"/> service and setup the <see cref="HttpClient.BaseAddress"/>
        /// </summary>
        /// <param name="context">The <see cref="ServiceConfigurationContext"/> object.</param>
        /// <param name="environment">The <see cref="IWebAssemblyHostEnvironment"/> object.</param>
        private void ConfigureHttpClient(ServiceConfigurationContext context, IWebAssemblyHostEnvironment environment, IConfiguration configuration)
        {
            var baseAddress = configuration["RemoteServices:Default:BaseUrl"];

            if (environment.IsProduction())
                baseAddress = "http://myhostname.com";
            Console.WriteLine($"++++++++++++++++++++++++++++baseAddress: {baseAddress}");
            
            context.Services.AddScoped( provider => new HttpClient 
            {
                BaseAddress = new Uri(baseAddress)
            });
        }

        /// <summary>
        /// Registers common services
        /// </summary>
        /// <param name="context">The <see cref="ServiceConfigurationContext"/> object.</param>
        private void ConfigureCommonServices(ServiceConfigurationContext context)
        {
            context.Services.AddAntDesign();
            context.Services.AddSingleton<Common>();
        }
    }
}