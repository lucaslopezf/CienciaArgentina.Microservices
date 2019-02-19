using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Entities.Models.JobOffer
{
    public class JobOfferUserLanguajeKnoweldge
    {
        [Key]
        public int Id { get; set; }
        public JobOffer JobOffer { get; set; }
        public string Condition { get; set; }
    }
}
