using System.Threading.Tasks;
using CienciaArgentina.Microservices.Storage.Azure.BlobStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using CienciaArgentina.Microservices.Storage.Azure.TableStorage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CienciaArgentina.Microservices.Storage.Azure
{
	public class FullStorageInitializer
	{
		public static async void Initialize()
		{
			var account = AzureStorageAccount.DefaultAccount;
            await new QueueStorageInitializer<AppException>(account).Initialize();
            await new QueueStorageInitializer<MailMessage>(account).Initialize();
            await new TableStorageInitializer<AppExceptionData>(account).Initialize();
            await new DocumentStorageInitializer(account, AzureStorageContainer.UserFiles).Initialize(BlobContainerPublicAccessType.Container);

        }
    }
}