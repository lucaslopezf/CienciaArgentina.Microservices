using System;
using System.Collections.Generic;
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
  //         var query = new TableQuery<AppExceptionData>().Where(
  //              TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, date.ToString("yyyyMMdd")));

  //          return _table.ExecuteQuery(query);
		//}
    }
}