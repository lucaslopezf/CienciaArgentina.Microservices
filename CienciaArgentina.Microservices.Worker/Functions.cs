using System;
using System.IO;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.QueueConsumers;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;

namespace CienciaArgentina.Microservices.Worker
{
    public class Functions
    {
        private readonly IConfigurationRoot _config;
        public Functions(IConfigurationRoot config)
        {
            _config = config;
        }
        public async Task ProcessAppExceptions([QueueTrigger(nameof(AppException))] string queueMessage, DateTimeOffset expirationTime, DateTimeOffset insertionTime, DateTimeOffset nextVisibleTime, string id, string popReceipt, int dequeueCount, string queueTrigger, CloudStorageAccount cloudStorageAccount, TextWriter logger)
        {
            var queueM = MessageQueue<AppException>.GenerateQueueMessage(queueMessage, expirationTime, insertionTime, nextVisibleTime, id, popReceipt, dequeueCount, queueTrigger, cloudStorageAccount);

            await new AppExceptionsSaver().ProcessMessages(queueM);

            logger.WriteLine($"AppExceptionsSaver: {queueM.Data.CustomMessage}");
        }

        public async Task MailsMessagesSender([QueueTrigger(nameof(MailMessage))] string queueMessage, DateTimeOffset expirationTime, DateTimeOffset insertionTime, DateTimeOffset nextVisibleTime, string id, string popReceipt, int dequeueCount, string queueTrigger, CloudStorageAccount cloudStorageAccount, TextWriter logger)
        {
            var queueM = MessageQueue<MailMessage>.GenerateQueueMessage(queueMessage, expirationTime, insertionTime, nextVisibleTime, id, popReceipt, dequeueCount, queueTrigger, cloudStorageAccount);

            var mailServer = _config.GetSection("EmailSettings:MailServer").ToString();
            var userName = _config.GetSection("EmailSettings:UserName").ToString();
            var password = _config.GetSection("EmailSettings:Password").ToString();
            var port = _config.GetSection("EmailSettings:Port").ToString();
            await new MailsMessagesSender(mailServer, port, userName, password).ProcessMessages(queueM);

            logger.WriteLine($"MailsMessagesSender: {queueM.Data.Subject} (f: {queueM.Data.From} |t: {queueM.Data.To})");
        }
    }
}
