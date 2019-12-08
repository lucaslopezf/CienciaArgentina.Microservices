using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Commons.Mail.ModelTemplates
{
    public class SendGetPasswordResetTokenModel
    {
        public SendGetPasswordResetTokenModel(string userName, string url)
        {
            UserName = userName;
            Url = url;
        }

        public string UserName { get; }
        public string Url { get; }
    }
}
