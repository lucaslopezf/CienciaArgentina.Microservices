using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class JobOfferCandidateReferral : EntityDateModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public JobReferral JobReferral { get; set; }
        public string Description { get; set; }
    }
}
