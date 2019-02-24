using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Entities.Models.Organizations
{
    public class OrganizationProjectImages : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public OrganizationProject OrganizationProject { get; set; }
    }
}
