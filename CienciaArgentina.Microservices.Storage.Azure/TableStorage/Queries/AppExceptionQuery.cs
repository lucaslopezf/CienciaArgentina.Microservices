using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace CienciaArgentina.Microservices.Storage.Azure.TableStorage.Queries
{
	public class AppExceptionQuery
	{
		private readonly CloudTable _table;

		public AppExceptionQuery(CloudStorageAccount account)
		{
		    var tableClient = account.CreateCloudTableClient();
            _table = tableClient.GetTableReference(nameof(AppException));
        }

        //TODO: GetExceptions
        //public IEnumerable<AppExceptionData> GetExceptions(DateTime date)
        //{
        //    var query = new TableQuery<AppExceptionData>().Where(
        //         TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, date.ToString("yyyyMMdd")));

        //    return _table.ExecuteQuery(query);
        //}

        public async Task<IEnumerable<AppExceptionData>> GetExceptions(string idFront)
        {
            var filterForIdFront = TableQuery.GenerateFilterCondition(
                nameof(AppExceptionData.IdFront),
                QueryComparisons.Equal, idFront);

            var query = new TableQuery<AppExceptionData>().Where(filterForIdFront);
            TableContinuationToken continuationToken = null;
            var listExceptions = new List<AppExceptionData>();
            do
            {
                var page = await _table.ExecuteQuerySegmentedAsync(query, continuationToken);
                continuationToken = page.ContinuationToken;
                listExceptions.AddRange(page.Results);
            } while (continuationToken != null);

            return listExceptions;
        }

        public async Task<IEnumerable<AppExceptionData>> GetExceptions()
        {
            var query = new TableQuery<AppExceptionData>();
            TableContinuationToken continuationToken = null;
            var listExceptions = new List<AppExceptionData>();
            do
            {
                var page = await _table.ExecuteQuerySegmentedAsync(query, continuationToken);
                continuationToken = page.ContinuationToken;
                listExceptions.AddRange(page.Results);
            } while (continuationToken != null);

            return listExceptions;
        }
    }
}