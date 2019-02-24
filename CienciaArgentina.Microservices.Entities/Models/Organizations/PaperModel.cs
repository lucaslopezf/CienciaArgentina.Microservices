using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.Organizations
{
    public class Paper : BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Magazine { get; set; }
        public string Link { get; set; }
    }
}
