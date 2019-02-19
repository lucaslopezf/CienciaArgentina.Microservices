using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.User
{
    public class JobType : BaseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
