using System.Threading.Tasks;

namespace CienciaArgentina.Microservices.Commons.Mail.Interfaces
{
    public interface IEmailClientSender
    {
        Task SendHelloWorldEmail(string email, string name);
    }
}
