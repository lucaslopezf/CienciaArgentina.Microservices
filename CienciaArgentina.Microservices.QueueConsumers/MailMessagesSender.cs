using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Commons.Extensions;
using CienciaArgentina.Microservices.Commons.Mail;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using System.Configuration;
using MailMessage = CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages.MailMessage;

namespace CienciaArgentina.Microservices.QueueConsumers
{
    public class MailsMessagesSender : IQueueMessageConsumer<MailMessage>
    {
        public static readonly TimeSpan EstimatedTime = TimeSpan.FromSeconds(5);

        public MailsMessagesSender(string mailServer, string port, string userName, string password)
        {
            MailServer = $"{mailServer}:{port}";
            UserName = userName;
            Password = password;
        }
        private string MailServer { get; }
        private string UserName { get; }
        private string Password { get; }

        public TimeSpan? EstimatedTimeToProcessMessageBlock { get; }

        public async Task ProcessMessages(QueueMessage<MailMessage> message)
        {
            try
            {
                var mailSender = new GeneralMailSender(MailServer, UserName, Password);
                var mailMessage = new System.Net.Mail.MailMessage(
                    message.Data.From,
                    message.Data.To,
                    message.Data.Subject,
                    message.Data.Body)
                {
                    IsBodyHtml = true,
                    From = new MailAddress(message.Data.From, "Ciencia Argentina"),
                };

                if (!string.IsNullOrWhiteSpace(message.Data.Cc)) mailMessage.CC.Add(message.Data.Cc);
                // si el mensaje es null significa que el maker controló algunas situaciones y no hay nada para enviar y el mensaje se puede remover de la queue
                await mailSender.SendAsync(mailMessage);

                Console.WriteLine($@"Email sent ({message.Data.Subject}) to: {message.Data.To}");
            }
            catch (Exception e)
            {
                e.Log(null, "Enviando mail key GeneralMailSender");
                var exmsg = $"Enviando mail : {e.Message}\nStackTrace:{e.StackTrace}";
                Console.WriteLine(exmsg, @"Error");
                if (message.DequeueCount < 20)
                {
                    throw;
                }
            }
        }
    }
}
