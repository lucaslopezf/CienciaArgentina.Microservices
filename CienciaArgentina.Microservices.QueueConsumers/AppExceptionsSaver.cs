using System;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Storage.Azure;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using CienciaArgentina.Microservices.Storage.Azure.TableStorage;

namespace CienciaArgentina.Microservices.QueueConsumers
{
    public class AppExceptionsSaver : IQueueMessageConsumer<AppException>
    {
        public static readonly TimeSpan EstimatedTime = TimeSpan.FromSeconds(40);
        public TimeSpan? EstimatedTimeToProcessMessageBlock { get; }

        private static TablePersister<AppExceptionData> _tablePersister;

        public AppExceptionsSaver()
        {
            EstimatedTimeToProcessMessageBlock = EstimatedTime;

            var tableClient = AzureStorageAccount.DefaultAccount.CreateCloudTableClient();
            _tablePersister = new TablePersister<AppExceptionData>(tableClient);
        }


        public async Task ProcessMessages(QueueMessage<AppException> message)
        {
            if (message.DequeueCount > 100)
                return;

            var messageLog = message.Data;
            if (_tablePersister == null) return;

            await _tablePersister.AddAsync(new AppExceptionData(message.Id,
                messageLog.Date ?? (message.InsertionTime?.DateTime ?? DateTime.UtcNow))
            {
                CustomMessage = messageLog.CustomMessage,
                Url = messageLog.Url,
                UrlReferrer = messageLog.UrlReferrer,
                Message = messageLog.Message,
                StackTrace = messageLog.Detail,
                IdFront = messageLog.IdFront
            });
        }
    }

}
