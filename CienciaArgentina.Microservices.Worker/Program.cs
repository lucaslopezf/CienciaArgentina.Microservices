using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace CienciaArgentina.Microservices.Worker
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976

    //Example: https://github.com/Azure/azure-webjobs-sdk/blob/dev/sample/SampleHost/Program.cs
    //Example2: https://jmezach.github.io/2017/10/29/having-fun-with-the-.net-core-generic-host/
    //Example3: https://github.com/mattosaurus/AzureBackup/tree/master/AzureBackup
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureHostConfiguration((config) =>
                {
                    config.AddEnvironmentVariables();
                })
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.SetBasePath(Environment.CurrentDirectory);
                    config.AddJsonFile("appsettings.json", optional: false,reloadOnChange:true);
                    config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    config.AddEnvironmentVariables();
                })
                //.UseEnvironment("Development")
                .ConfigureWebJobs(b =>
                {
                    b.AddAzureStorageCoreServices()
                        .AddAzureStorage();
                });
          
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
