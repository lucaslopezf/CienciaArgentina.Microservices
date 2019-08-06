using Microsoft.WindowsAzure.Storage;
using System.Configuration;

namespace CienciaArgentina.Microservices.Storage.Azure
{
    public sealed class AzureStorageAccount
    {
        private static string DefaultDataConnectionString { get; set; }

        public static void Init(string connectionString)
        {
            DefaultDataConnectionString = connectionString;
        }

        public static CloudStorageAccount DefaultAccount => CloudStorageAccount.TryParse(DefaultDataConnectionString, out var account) ?
            account :
            CloudStorageAccount.DevelopmentStorageAccount;
    }
}