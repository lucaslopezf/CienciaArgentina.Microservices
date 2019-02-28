using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Commons.Helpers.Mail;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using MailMessage = CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages.MailMessage;

namespace CienciaArgentina.Microservices.QueueConsumers
{
    public class MailSender : IQueueMessageConsumer<MailMessage>
    {
        public static readonly TimeSpan EstimatedTime = TimeSpan.FromSeconds(5);
        public TimeSpan? EstimatedTimeToProcessMessageBlock { get; }

        public async Task ProcessMessages(QueueMessage<MailMessage> mail)
        {
            var mailserver = "smtp.gmail.com:587";
            var username = "usuarioscienciaargentina@gmail.com";
            var password = "Hola1234*";

            var sender = new MailHelper(mailserver, username, password);

            var message = new System.Net.Mail.MailMessage(mail.Data.From, mail.Data.To, mail.Data.Subject, mail.Data.Body)
            {
                IsBodyHtml = true,
                From = new MailAddress(mail.Data.From, "Ciencia Argentina")
            };

            if (!string.IsNullOrWhiteSpace(mail.Data.Cc)) message.CC.Add(mail.Data.Cc);
            // si el mensaje es null significa que el maker controló algunas situaciones y no hay nada para enviar y el mensaje se puede remover de la queue
            sender.Send(message);

            Console.WriteLine($@"Email sent ({mail.Data.Subject}) to: {mail.Data.To}");
        }
    }
}
