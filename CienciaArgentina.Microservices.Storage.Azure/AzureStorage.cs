using Microsoft.WindowsAzure.Storage;
using System.Configuration;

namespace CienciaArgentina.Microservices.Storage.Azure
{
    public sealed class AzureStorageAccount
    {
        private const string DefaultDataConnectionString = "UseDevelopmentStorage=true";

        //TODO: Get connectionString from appsettings
        public static CloudStorageAccount DefaultAccount => CloudStorageAccount.TryParse(DefaultDataConnectionString, out var account) ?
            account :
            CloudStorageAccount.DevelopmentStorageAccount;
    }
}