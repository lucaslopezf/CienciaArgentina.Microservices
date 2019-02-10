using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;

namespace CienciaArgentina.Microservices.Storage.Azure.QueueStorage
{
    public class QueueMessageBlockConsumer<TMessage> : MessageBlockPoolQueueConsumer<TMessage> where TMessage : class
    {
        public QueueMessageBlockConsumer(IQueueMessageBlocksConsumer<TMessage> consumer) : base(consumer) { }

        protected override Thread CreateThreadForPolling()
        {
            var consumerName = ConsumerName;
            Trace.WriteLine("Starting " + consumerName, "Information");

            return new Thread(PollQueue) { Name = consumerName };
        }

        protected override CloudStorageAccount QueueAccount => AzureStorageAccount.DefaultAccount;
    }
}
