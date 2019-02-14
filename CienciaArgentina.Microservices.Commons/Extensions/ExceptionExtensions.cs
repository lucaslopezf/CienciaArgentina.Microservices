using System;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;

namespace CienciaArgentina.Microservices.Commons.Extensions
{
    public enum ExceptionAction
    {
        Enqueue = 0,
        SendMail = 1,
        SendMailAndEnqueue = 2,
    }

    public static class ExceptionExtensions
    {
        //TODO: Return NOT void. Problem with ExceptionMiddleware 
        public static async void Log(this Exception exception, HttpContext context, Guid idGuid, string source = "Microservices", string customMessage = "CienciaArgentina.Error", ExceptionAction action = ExceptionAction.Enqueue)
        {

            var url = "Not available";
            var urlreferer = "Not available";

            if (context != null)
            {
                var request = context.Request;
                urlreferer = context.Request.Headers["Referer"].ToString();

                url = $"{request.Scheme}://" +
                      $"{request.Host.ToUriComponent()}" +
                      $"{request.PathBase.ToUriComponent()}" +
                      $"{request.Path.ToUriComponent()}" +
                      $"{request.QueryString.ToUriComponent()}";
                
                if (context.User?.Identity != null && context.User.Identity.IsAuthenticated)
                {
                    customMessage += $"| LoggedUser: {context.User.Identity.Name}";
                }

            }

            var message = new AppException
            {
                IdFront = idGuid.ToString(),
                CustomMessage = customMessage,
                Message = exception.Message,
                Detail = exception.StackTrace,
                Url = url,
                UrlReferrer = urlreferer,
                Source = source
            };

            try
            {
                if (ExceptionAction.Enqueue.Equals(action) || ExceptionAction.SendMailAndEnqueue.Equals(action))
                {
                    await AzureQueue.Enqueue(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //estamos en la B, error del error
            }

            try
            {
                if (ExceptionAction.SendMail.Equals(action) || ExceptionAction.SendMailAndEnqueue.Equals(action))
                {
                    //TODO: Hacer mail

                    //var mailserver = ConfigurationManager.AppSettings["Mail.Server"];
                    //var username = ConfigurationManager.AppSettings["Mail.Username"];
                    //var password = ConfigurationManager.AppSettings["Mail.Password"];
                    //var from = ConfigurationManager.AppSettings["Mail.From"];
                    //var adminmail = ConfigurationManager.AppSettings["AdminEmails"];

                    //var mailSender = new GeneralMailSender(mailserver, username, password);
                    //var mailMessage = new System.Net.Mail.MailMessage(from, adminmail?.Split(',')[0] ?? throw new InvalidOperationException(), message.CustomMessage, message.Url + "\n\n" + message.UrlReferrer + "\n\n" + message.Exception);

                    // si el mensaje es null significa que el maker controló algunas situaciones y no hay nada para enviar y el mensaje se puede remover de la queue
                    //mailSender.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var ai = new TelemetryClient();
                ai.TrackException(exception);
            }
            catch (Exception)
            {
                //estamos en la B, error del error
            }
        }

        public static async void Log(this Exception exception, HttpContext context, string source = "Microservices",string customMessage = "CienciaArgentina.Error", ExceptionAction action = ExceptionAction.Enqueue)
        {

            var url = "Not available";
            var urlreferer = "Not available";

            if (context != null)
            {
                var request = context.Request;
                urlreferer = context.Request.Headers["Referer"].ToString();

                url = $"{request.Scheme}://" +
                      $"{request.Host.ToUriComponent()}" +
                      $"{request.PathBase.ToUriComponent()}" +
                      $"{request.Path.ToUriComponent()}" +
                      $"{request.QueryString.ToUriComponent()}";

                if (context.User?.Identity != null && context.User.Identity.IsAuthenticated)
                {
                    customMessage += $"| LoggedUser: {context.User.Identity.Name}";
                }

            }

            var message = new AppException
            {
                CustomMessage = customMessage,
                Message = exception.Message,
                Detail = exception.StackTrace,
                Url = url,
                UrlReferrer = urlreferer,
                Source = source
            };

            try
            {
                if (ExceptionAction.Enqueue.Equals(action) || ExceptionAction.SendMailAndEnqueue.Equals(action))
                {
                   await AzureQueue.Enqueue(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //estamos en la B, error del error
            }

            try
            {
                if (ExceptionAction.SendMail.Equals(action) || ExceptionAction.SendMailAndEnqueue.Equals(action))
                {
                    //TODO: Hacer mail

                    //var mailserver = ConfigurationManager.AppSettings["Mail.Server"];
                    //var username = ConfigurationManager.AppSettings["Mail.Username"];
                    //var password = ConfigurationManager.AppSettings["Mail.Password"];
                    //var from = ConfigurationManager.AppSettings["Mail.From"];
                    //var adminmail = ConfigurationManager.AppSettings["AdminEmails"];

                    //var mailSender = new GeneralMailSender(mailserver, username, password);
                    //var mailMessage = new System.Net.Mail.MailMessage(from, adminmail?.Split(',')[0] ?? throw new InvalidOperationException(), message.CustomMessage, message.Url + "\n\n" + message.UrlReferrer + "\n\n" + message.Exception);

                    // si el mensaje es null significa que el maker controló algunas situaciones y no hay nada para enviar y el mensaje se puede remover de la queue
                    //mailSender.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //estamos en la B, error del error
            }

            try
            {
                var ai = new TelemetryClient();
                ai.TrackException(exception);
            }
            catch (Exception)
            {
                //estamos en la B, error del error
            }
        }
    }
}