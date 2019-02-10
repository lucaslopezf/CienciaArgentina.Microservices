using System;

namespace CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages
{
    [Serializable()]
    public class AppException
    {
        public DateTime? Date { get; set; }
        //public Exception Exception { get; set; }
        public Guid IdFront { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public int HResult { get; set; }
        public string CustomMessage { get; set; }
        public string Url { get; set; }
        public string UrlReferrer { get; set; }
    }
}
