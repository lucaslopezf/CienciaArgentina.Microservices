using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Worker
{
    public class EmailSettings
    {
        public string MailServer { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
    }
}
