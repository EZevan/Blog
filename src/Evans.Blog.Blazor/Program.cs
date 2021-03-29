using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Evans.Blog.Blazor.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Evans.Blog.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var application = builder.AddApplication<BlogBlazorModule>(options =>
            {
                // Need install "volo.abp.autofac.webassembly"
                options.UseAutofac();
            });
            
            //builder.RootComponents.Add<App>("#app");

            // builder.Services.AddScoped(sp => new HttpClient
            // {
            //     BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            // });

            var host = builder.Build();

            //await application.InitializeAsync(host.Services);

            await host.RunAsync();
        }
    }
}
