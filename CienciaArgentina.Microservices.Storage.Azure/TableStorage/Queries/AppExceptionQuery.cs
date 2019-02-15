using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.QueryParameters;
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

        public async Task<AppExceptionData> GetExceptions(string idFront)
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

            return listExceptions.FirstOrDefault();
        }
        public async Task<IQueryable<AppExceptionData>> GetExceptions(QueryParameters queryParameters)
        {
            var filterForCustomMessage = TableQuery.GenerateFilterCondition(
                nameof(AppExceptionData.Source),
                QueryComparisons.Equal, queryParameters.Query.ToLowerInvariant());

            var filterForUrl = TableQuery.GenerateFilterCondition(
                nameof(AppExceptionData.Url),
                QueryComparisons.Equal, queryParameters.Query.ToLowerInvariant());

            var filter = TableQuery.CombineFilters(filterForCustomMessage, TableOperators.Or, filterForUrl);

            var query = new TableQuery<AppExceptionData>().Where(filter);
            TableContinuationToken continuationToken = null;
            var listExceptions = new List<AppExceptionData>();
            do
            {
                var page = await _table.ExecuteQuerySegmentedAsync(query, continuationToken);
                continuationToken = page.ContinuationToken;
                listExceptions.AddRange(page.Results);
            } while (continuationToken != null);

            return listExceptions.AsQueryable();
        }

        public async Task<IQueryable<AppExceptionData>> GetExceptions()
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

            return listExceptions.AsQueryable();
        }

    }
}