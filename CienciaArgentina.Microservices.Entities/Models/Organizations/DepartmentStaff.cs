using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models.Addresses;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Entities.Models.Organizations
{
    public class DepartmentStaff : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public UserProfile UserProfile { get; set; }
        public Department Organization { get; set; }
    }
}
