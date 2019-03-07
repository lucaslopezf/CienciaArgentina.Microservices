using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.BusinessModel
{
    public class JwtToken
    {
        public JwtToken(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
        public string Token { get; }
        public DateTime Expiration { get; }
    }
}
