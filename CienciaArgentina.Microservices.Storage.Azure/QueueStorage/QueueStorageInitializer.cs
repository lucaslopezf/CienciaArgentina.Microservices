using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;

namespace CienciaArgentina.Microservices.Storage.Azure
{
	/// <summary>
	/// Initialize a queue storage specific for a message type.
	/// </summary>
	/// <typeparam name="TMessage">The typeof the message</typeparam>
	public class QueueStorageInitializer<TMessage> : IStorageInitializer where TMessage : class
	{
		private readonly CloudStorageAccount _account;
		private readonly string _queueName = typeof(TMessage).Name.ToLowerInvariant();

		public QueueStorageInitializer(CloudStorageAccount account)
		{
		    _account = account ?? throw new ArgumentNullException(nameof(account));
		}

		public async Task Initialize()
		{
			var queueClient = _account.CreateCloudQueueClient();
			var queue = queueClient.GetQueueReference(_queueName);
			await queue.CreateIfNotExistsAsync();
		}

		public async Task Drop()
		{
			var queueClient = _account.CreateCloudQueueClient();
		    var queue = queueClient.GetQueueReference(_queueName);
		    await queue.DeleteAsync();
		}
	}
}