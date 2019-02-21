using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.JobOffer
{
    public class JobOfferCandidateReferral : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public JobReferral JobReferral { get; set; }
        public string Description { get; set; }
    }
}
