using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Commons.Mail.ModelTemplates
{
    public class SendConfirmationAccountModel
    {
        public SendConfirmationAccountModel(string nombre, string apellido, string url)
        {
            Nombre = nombre;
            Apellido = apellido;
            Url = url;
        }

        public string Nombre { get; }
        public string Apellido { get; }
        public string Url { get; }
    }
}
