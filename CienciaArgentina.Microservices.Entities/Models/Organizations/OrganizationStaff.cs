using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models.Addresses;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Entities.Models.Organizations
{
    public class OrganizationStaff : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public UserData UserData { get; set; }
        public Organization Organization { get; set; }
    }
}
