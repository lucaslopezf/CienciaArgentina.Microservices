using Microsoft.WindowsAzure.Storage;
using System.Configuration;

namespace CienciaArgentina.Microservices.Storage.Azure
{
    public sealed class AzureStorageAccount
    {
        private const string DefaultDataConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagecienciaarg1;AccountKey=//glQwLj+0Wd6r4oxsgSJbJZ1LyM7gGO+aaTg3X5ubk5/8sTW3SUCY/ti/mKuuJ1CpKvLRcSwJPiVBmvdoRCUQ==;EndpointSuffix=core.windows.net";

        //TODO: Get connectionString from appsettings
        public static CloudStorageAccount DefaultAccount => CloudStorageAccount.TryParse(DefaultDataConnectionString, out var account) ?
            account :
            CloudStorageAccount.DevelopmentStorageAccount;
    }
}