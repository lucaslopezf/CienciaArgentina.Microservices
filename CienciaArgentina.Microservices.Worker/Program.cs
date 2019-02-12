using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;


namespace CienciaArgentina.Microservices.Worker
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976

    //Example: https://github.com/Azure/azure-webjobs-sdk/blob/dev/sample/SampleHost/Program.cs
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .UseEnvironment("Development")
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
