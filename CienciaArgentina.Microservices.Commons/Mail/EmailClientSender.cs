﻿using System.Threading.Tasks;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Commons.Helpers;
using CienciaArgentina.Microservices.Commons.Helpers.Razor;
using CienciaArgentina.Microservices.Commons.Mail.Interfaces;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;

namespace CienciaArgentina.Microservices.Commons.Mail
{
    public class EmailClientSender : IEmailClientSender
    {
        //https://medium.com/@ognjanovski.gavril/net-core-email-sender-library-with-razor-templates-cshtml-contained-in-it-71c48bef1457
        public async Task SendHelloWorldEmail(string email, string name)
        {
            string template = "Mail.Templates.HelloWorldTemplate";

            RazorParser renderer = new RazorParser(typeof(EmailClient).Assembly);
            var body = renderer.UsingTemplateFromEmbedded(template,
                new LogDto { Message = name });

            await SendEmailAsync(email, "Email Subject", body);
        }

        private static async Task SendEmailAsync(string email, string subject, string message,string fromEmail = "no-reply@cienciaargentina.com.ar")
        {
            var mailMessage = new MailMessage
            {
                From = fromEmail,
                To = email,
                Body = message,
                Subject = subject
            };

            await AzureQueue.EnqueueAsync(mailMessage);
        }

    }
}
