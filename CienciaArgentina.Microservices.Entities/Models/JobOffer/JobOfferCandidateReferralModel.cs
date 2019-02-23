using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Identity;

namespace CienciaArgentina.Microservices.Entities.Models.JobOffer
{
    public class JobOfferCandidateReferral : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public JobReferral JobReferral { get; set; }
        public string Description { get; set; }

        //For identity
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
