using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CienciaArgentina.Microservices.Storage.Azure.BlobStorage
{
	public class DocumentStorageInitializer : IStorageInitializer
	{
		private readonly CloudStorageAccount _account;
		private readonly string _documentsContainerName;

		public DocumentStorageInitializer(CloudStorageAccount account, string documentsContainerName)
		{
		    if (string.IsNullOrWhiteSpace(documentsContainerName))
			{
				throw new ArgumentNullException(nameof(documentsContainerName));
			}
			_account = account ?? throw new ArgumentNullException(nameof(account));
			_documentsContainerName = documentsContainerName.ToLowerInvariant();
		}

		public virtual string DocumentsContainerName => _documentsContainerName;

	    public async Task Initialize()
        {
           await Initialize(BlobContainerPublicAccessType.Off);
        }

	    public async Task Initialize(BlobContainerPublicAccessType accessType)
		{
			var blobStorageType = _account.CreateCloudBlobClient();
			var container = blobStorageType.GetContainerReference(_documentsContainerName);
			await container.CreateIfNotExistsAsync();
			var perm = new BlobContainerPermissions
			{
                PublicAccess = accessType
			};
			await container.SetPermissionsAsync(perm);
		}

		public async Task Drop()
		{
			var blobStorageType = _account.CreateCloudBlobClient();

            var container = blobStorageType.GetContainerReference(_documentsContainerName);
		    await container.DeleteAsync();
		}
	}

	public class DocumentStorageInitializer<TDocument> : DocumentStorageInitializer where TDocument : class
	{
		public DocumentStorageInitializer(CloudStorageAccount account)
			: base(account, typeof(TDocument).Name.ToLowerInvariant())
		{
		}
	}
}