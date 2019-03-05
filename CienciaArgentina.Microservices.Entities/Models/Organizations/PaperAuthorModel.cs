using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Entities.Models.Organizations
{
    public class PaperAuthor : BaseModel
    {
        public int Id { get; set; }
        // TODO: Repensar esto
        public string UserName { get; set; } // Si la persona no existe le pones nombre y apellido
        public string Role { get; set; }
        public Paper Paper { get; set; }
    }
}
