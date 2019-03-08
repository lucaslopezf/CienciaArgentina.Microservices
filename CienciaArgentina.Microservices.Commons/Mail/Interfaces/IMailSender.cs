using System.Net.Mail;
using System.Threading.Tasks;

namespace CienciaArgentina.Microservices.Commons.Mail.Interfaces
{
    public interface IMailSender
    {
        Task SendAsync(MailMessage mail);
    }
}
