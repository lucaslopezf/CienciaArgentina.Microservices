using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace CienciaArgentina.Microservices.Entities.BusinessModel
{
    public class LoginModel
    {
        public LoginModel(bool result = false)
        {
            Response = new ResponseModel(result);
        }

        public void Success(bool result)
        {
            this.Response.Success = result;
        }

        public void AddError(ErrorResponseModel error)
        {
            Response.AddError(error);
        }
        public JwtToken JwtToken { get; set; }

        public ResponseModel Response { get; set; }
        public string Email { get; set; }
    }
}
