using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace CienciaArgentina.Microservices.Storage.Azure.TableStorage
{
	public class TablePersister<TDataRow> : IPersister<TDataRow> where TDataRow : TableEntity
	{
		private readonly CloudTable table;
		private readonly string entityTableName = typeof(TDataRow).AsTableStorageName();

        public TablePersister(CloudTableClient tableClient)
		{
            if (tableClient == null)
			{
                throw new ArgumentNullException(nameof(tableClient));
			}
            table = tableClient.GetTableReference(entityTableName);
		}

		public async Task<TDataRow> Get(string partitionKey, string rowKey)
		{
		    try
		    {
                var retrieveOperation = TableOperation.Retrieve<TDataRow>(partitionKey, rowKey);

                var retrievedResult = await table.ExecuteAsync(retrieveOperation);

                return (TDataRow)retrievedResult.Result;
		    }
		    catch (StorageException e)
		    {
                if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
		        {
		            return null;
		        }
		        throw;
		    }
		}

        public async Task AddBatch(TableBatchOperation tableOperation)
        {
            await table.ExecuteBatchAsync(tableOperation);
        }
        public async Task AddBatchAsync(TableBatchOperation tableOperation)
        {
            await table.ExecuteBatchAsync(tableOperation);
        }

        public async Task Add(TDataRow dataRow)
        {
            var op = TableOperation.Insert(dataRow);
            await table.ExecuteAsync(op);
        }

        public async Task AddAsync(TDataRow dataRow)
        {
            var op = TableOperation.Insert(dataRow);
            await table.ExecuteAsync(op);
        }

        public async Task Update(TDataRow dataRow)
        {
            var op = TableOperation.Replace(dataRow);
            await table.ExecuteAsync(op);
        }

        public async Task UpdateAsync(TDataRow dataRow)
        {
            var op = TableOperation.Replace(dataRow);
            await table.ExecuteAsync(op);
        }

        public async Task Delete(string partitionKey, string rowKey)
		{
			var entity = await Get(partitionKey, rowKey);
		    if (entity == null) return;

		    var op = TableOperation.Delete(entity);
		    await table.ExecuteAsync(op);
		}

		public async Task Delete(TDataRow dataRow)
		{
			await Delete(dataRow.PartitionKey, dataRow.RowKey);
		}
	}
}