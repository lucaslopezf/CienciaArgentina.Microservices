using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Entities.Commons;
using Microsoft.AspNetCore.Identity;

namespace CienciaArgentina.Microservices.Entities.BusinessModel
{
    public class LoginModel
    {
        public LoginModel(string email)
        {
            Email = email;
        }

        public void AddToken(JwtToken token)
        {
            JwtToken = token;
        }

        public JwtToken JwtToken { get; private set; }

        public void AddEmail(string email)
        {
            Email = email;
        }
        public string Email { get; private set; }
    }
}
