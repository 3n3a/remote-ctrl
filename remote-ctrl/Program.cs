using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using remote_ctrl;

namespace remote_ctrl
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel()
                        .UseStartup<Startup>()
                        .UseUrls("http://0.0.0.0:1384");
                });
        }
    }
}