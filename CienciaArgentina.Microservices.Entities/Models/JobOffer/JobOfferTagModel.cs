using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.JobOffer
{
    public class JobOfferTag : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public JobOffer JobOffer { get; set; }
        public Tag Tag { get; set; }
    }
}
