using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Identity;

namespace CienciaArgentina.Microservices.Entities.Models.JobOffer
{
    public class JobOfferCandidate : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public decimal ExpectedSalary { get; set; }
        public string CV { get; set; }
        // TODO: Add JobOffer
        public string State { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string IntroductionLetter { get; set; }
        public string CandidateNote { get; set; }

        //For identity
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
