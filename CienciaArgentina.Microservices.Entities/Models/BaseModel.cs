using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class BaseModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }

        public BaseModel()
        {
            DateCreated = DateTime.Now;
            DateDeleted = null;
        }
    }
}
