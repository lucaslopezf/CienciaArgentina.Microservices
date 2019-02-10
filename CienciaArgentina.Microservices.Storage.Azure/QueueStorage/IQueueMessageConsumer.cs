using System;
using System.Threading.Tasks;

namespace CienciaArgentina.Microservices.Storage.Azure.QueueStorage
{
    public interface IQueueMessageConsumer<TMessage>
    {
        TimeSpan? EstimatedTimeToProcessMessageBlock { get; }
        Task ProcessMessages(QueueMessage<TMessage> message);
    }
}
