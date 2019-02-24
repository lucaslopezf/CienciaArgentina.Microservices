using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.Organizations
{
    public class PaperDepartment : BaseModel
    {
        public int Id { get; set; }
        public Department Deparment { get; set; }
        public Paper Paper { get; set; }
    }
}
