using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Commons.Mail.ModelTemplates
{
    public class SendResetPasswordModel
    {
        public SendResetPasswordModel(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
