using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.JobOffer
{
    public class JobOfferCandidate : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public decimal ExpectedSalary { get; set; }
        public string CV { get; set; }
        // TODO: Add JobOffer
        public string State { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string IntroductionLetter { get; set; }
        public string CandidateNote { get; set; }
    }
}
