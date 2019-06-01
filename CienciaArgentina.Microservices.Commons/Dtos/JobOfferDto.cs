using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models.Addresses;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Commons.Dtos
{
    public class JobOfferDto
    {
        public int EmployerId { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        [Column(TypeName = "Date")]
        public DateTime MinBirthday { get; set; }
        [Column(TypeName = "Date")]
        public DateTime MaxBirthday { get; set; }
        public int Address { get; set; }
        public bool Experience { get; set; }
        public int JobType { get; set; }
        public string AcademicRequirements { get; set; }
        public string ProjectDescription { get; set; }
        public string ResearchTopics { get; set; }
        public string ExperimentalModel { get; set; }
        public DateTime DurationOffer { get; set; }
        public bool PresentationLetter { get; set; }
        public string CareerState { get; set; } //Si tiene que estar finalizada la carrera, etc.
        public DateTime DateCareerFinish { get; set; } //Tiene que terminar la carrera antes de..
        public string ProjectManager { get; set; } //Responsable del proyecto
        public string ContactEmail { get; set; }
    }
}
