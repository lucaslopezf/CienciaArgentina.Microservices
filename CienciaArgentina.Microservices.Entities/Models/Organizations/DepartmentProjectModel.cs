using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.Organizations
{
    public class DepartmentProject : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public Department Department { get; set; }
        public OrganizationProject OrganizationProject { get; set; }
    }
}
