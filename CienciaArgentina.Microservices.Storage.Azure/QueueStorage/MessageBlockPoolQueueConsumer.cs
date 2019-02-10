using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;

namespace CienciaArgentina.Microservices.Storage.Azure.QueueStorage
{
    public abstract class MessageBlockPoolQueueConsumer<TMessage> : AbstractQueueConsumer<TMessage> where TMessage : class
    {
        protected MessageBlockPoolQueueConsumer(IQueueMessageBlocksConsumer<TMessage> consumer)
        {
            Consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
        }

        protected IQueueMessageBlocksConsumer<TMessage> Consumer { get; private set; }

        protected virtual string ConsumerName => Consumer.GetType().Name;

        protected abstract CloudStorageAccount QueueAccount { get; }

        public override async void PollQueue()
        {
            CloudStorageAccount account = QueueAccount;
            var queue = new MessageQueue<TMessage>(account);
            var queueRemover = GetQueueRemover(queue);
            IPoolingFrequencer frequencer = Frequencer;
            bool useDefaultTimeout = !Consumer.EstimatedTimeToProcessMessageBlock.HasValue;
            TimeSpan defaultTimeout = useDefaultTimeout ? TimeSpan.FromSeconds(30) : Consumer.EstimatedTimeToProcessMessageBlock.Value;
            while (true)
            {
                try
                {
                    var messages = useDefaultTimeout ? await queue.Dequeue(Consumer.BlockSize) : await queue.Dequeue(Consumer.BlockSize, defaultTimeout);
                    var queueMessages = messages.ToList();
                    if (queueMessages.Any())
                    {
                        try
                        {
                            Consumer.ProcessMessagesGroup(queueRemover, queueMessages);
                        }
                        catch (Exception e)
                        {
                            OnProcessMessageLogException(queueMessages, e);
                        }
                        finally
                        {
                            frequencer.Decrease();
                        }
                    }
                    else
                    {
                        Thread.Sleep(frequencer.Current);
                    }
                }
                catch (Exception e)
                {
                    OnDequeueLogException(e);
                    Thread.Sleep(5 * 1000);
                }
            }
        }

        protected virtual IQueueMessageRemover<TMessage> GetQueueRemover(MessageQueue<TMessage> queue)
        {
            return new QueueMessageRemover<TMessage>(queue);
        }

        protected virtual void OnDequeueLogException(Exception e)
        {
            string message = $"Queue connection of {ConsumerName}: {e.Message}\nStackTrace:{e.StackTrace}";
            Trace.WriteLine(message, "Error");
        }

        protected virtual void OnProcessMessageLogException(IEnumerable<QueueMessage<TMessage>> messages, Exception e)
        {
            var errorMessage = $"{ConsumerName}: {e.Message}\nStackTrace:{e.StackTrace}";
            Trace.WriteLine(errorMessage, "Error");
        }

        protected class QueueMessageRemover<TMessage> : IQueueMessageRemover<TMessage> where TMessage : class
        {
            private readonly MessageQueue<TMessage> _queue;

            public QueueMessageRemover(MessageQueue<TMessage> queue)
            {
                _queue = queue;
            }

            public async Task RemoveProcessedMessages(IEnumerable<QueueMessage<TMessage>> sucefullyProcessedMessages)
            {
                await _queue.Remove(sucefullyProcessedMessages);
            }

            public async Task RemoveProcessedMessage(QueueMessage<TMessage> sucefullyProcessedMessage)
            {
                await _queue.Remove(sucefullyProcessedMessage);
            }
        }
    }
}
