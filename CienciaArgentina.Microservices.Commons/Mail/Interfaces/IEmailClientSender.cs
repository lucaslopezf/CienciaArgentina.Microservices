using System.Threading.Tasks;
using CienciaArgentina.Microservices.Commons.Mail.ModelTemplates;

namespace CienciaArgentina.Microservices.Commons.Mail.Interfaces
{
    public interface IEmailClientSender
    {
        Task SendHelloWorldEmail(string email, string name);

        Task SendConfirmationAccounEmail(string email, SendConfirmationAccountModel model);
    }
}
