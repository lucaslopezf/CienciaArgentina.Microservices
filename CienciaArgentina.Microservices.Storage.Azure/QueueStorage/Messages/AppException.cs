using System;

namespace CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages
{
    public class AppException
    {
        public DateTime? Date { get; set; }
        public Exception Exception { get; set; }
        public string CustomMessage { get; set; }
        public string Url { get; set; }
        public string UrlReferrer { get; set; }
    }
}
