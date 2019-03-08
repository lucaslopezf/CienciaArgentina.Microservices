using System;
using System.IO;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.QueueConsumers;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;

namespace CienciaArgentina.Microservices.Worker
{
    public class Functions
    {
        private readonly IOptions<EmailSettings> _emailSettings;
        public Functions(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
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
            var mailServer = _emailSettings.Value.MailServer;
            var userName = _emailSettings.Value.UserName;
            var password = _emailSettings.Value.Password;
            var port = _emailSettings.Value.Port;
            await new MailsMessagesSender(mailServer, port, userName, password).ProcessMessages(queueM);

            logger.WriteLine($"MailsMessagesSender: {queueM.Data.Subject} (f: {queueM.Data.From} |t: {queueM.Data.To})");
        }
    }
}
