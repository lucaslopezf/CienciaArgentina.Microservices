using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CienciaArgentina.Microservices.Commons.Mail
{
    public interface IMailSender
    {
        Task SendAsync(MailMessage mail);
    }
}
