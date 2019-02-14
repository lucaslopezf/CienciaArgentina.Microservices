using System;

namespace CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages
{
    [Serializable()]
    public class AppException
    {
        public DateTime? Date { get; set; }
        public string IdFront { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public string CustomMessage { get; set; }
        public string Url { get; set; }
        public string UrlReferrer { get; set; }
        public string Source { get; set; }
    }
}
