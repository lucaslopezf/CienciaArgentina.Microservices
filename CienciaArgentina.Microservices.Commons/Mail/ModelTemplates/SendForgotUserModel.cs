using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Commons.Mail.ModelTemplates
{
    public class SendForgotUserModel
    {
        public SendForgotUserModel(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
