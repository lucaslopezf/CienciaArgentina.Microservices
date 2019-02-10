using System.Collections.Generic;
using System.Threading.Tasks;

namespace CienciaArgentina.Microservices.Storage.Azure.QueueStorage
{
    public interface IQueueMessageRemover<TMessage>
    {
        Task RemoveProcessedMessages(IEnumerable<QueueMessage<TMessage>> sucefullyProcessedMessages);
        Task RemoveProcessedMessage(QueueMessage<TMessage> sucefullyProcessedMessage);
    }
}
