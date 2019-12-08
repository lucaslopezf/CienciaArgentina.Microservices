using System.Threading.Tasks;
using CienciaArgentina.Microservices.Commons.Mail.ModelTemplates;

namespace CienciaArgentina.Microservices.Commons.Mail.Interfaces
{
    public interface IEmailClientSender
    {
        Task SendHelloWorldEmail(string email, string name);

        Task SendConfirmationAccountEmail(string email, SendConfirmationAccountModel model);

        Task SendForgotUser(string email, SendForgotUserModel model);
        Task SendGetPasswordResetToken(string email, SendGetPasswordResetTokenModel model);
    }
}
