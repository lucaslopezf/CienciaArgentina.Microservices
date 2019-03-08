using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.BusinessModel
{
    public class LoginModel
    {
        public JwtToken JwtToken { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
