using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.JobOffer
{
    public class Tag : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
