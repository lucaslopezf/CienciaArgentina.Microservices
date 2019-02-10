using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace CienciaArgentina.Microservices.Storage.Azure.TableStorage
{
	public class TableStorageInitializer<TTableEntity> : IStorageInitializer where TTableEntity : class
	{
		private readonly CloudStorageAccount _account;
		private readonly string _entityTableName = typeof (TTableEntity).AsTableStorageName();

		public TableStorageInitializer(CloudStorageAccount account)
		{
            this._account = account ?? throw new ArgumentNullException(nameof(account));
			var properties =
				typeof (TTableEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(pi => pi.Name).
					ToList();
			if (!properties.Contains("PartitionKey") || !properties.Contains("RowKey") || !properties.Contains("Timestamp"))
			{
				throw new ArgumentOutOfRangeException("TTableEntity",
				                                      "The type of the entity is not a valid Azure entity type.(it should contain at least the three required public properties: PartitionKey,RowKey,Timestamp");
			}
		}

		public async Task Initialize()
		{
			var client = new CloudTableClient(_account.TableEndpoint, _account.Credentials);
            var table = client.GetTableReference(_entityTableName);
            await table.CreateIfNotExistsAsync();
			// Execute conditionally for development storage only
            // AB: not necessary for SDK 2.0
			//if (client.BaseUri.IsLoopback)
			//{
			//	var instance = Activator.CreateInstance(typeof (TTableEntity), true);
			//	client.InitializeTableSchemaFromEntity(entityTableName, instance);
			//}
		}

		public async Task Drop()
		{
			var client = new CloudTableClient(_account.TableEndpoint, _account.Credentials);
		    var table = client.GetTableReference(_entityTableName);
			await table.DeleteIfExistsAsync();
		}
	}
}