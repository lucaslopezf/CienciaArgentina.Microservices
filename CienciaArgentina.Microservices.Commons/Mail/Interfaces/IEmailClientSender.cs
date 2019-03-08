using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CienciaArgentina.Microservices.Business.Interfaces
{
    public interface IEmailClientSender
    {
        Task SendHelloWorldEmail(string email, string name);
    }
}
