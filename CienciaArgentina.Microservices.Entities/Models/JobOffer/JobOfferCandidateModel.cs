using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.JobOffer
{
    public class JobOfferCandidate : EntityDateModel
    {
        public int Id { get; set; }
        public string State { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string IntroductionLetter { get; set; }
    }
}
