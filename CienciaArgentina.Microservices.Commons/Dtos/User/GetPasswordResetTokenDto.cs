using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Commons.Dtos
{
    public class GetPasswordResetTokenDto
    {
        public string Email { get; set; }
    }
}
