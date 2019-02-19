using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class JobOfferDescriptionModel : EntityDateModel
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
        public decimal Salary { get; set; }
        [Column(TypeName = "Date")]
        public DateTime MinBirthday { get; set; }
        [Column(TypeName = "Date")]
        public DateTime MaxBirthday { get; set; }

        public Address Address{ get; set; }
        public bool Experience { get; set; }
        public JobType JobType { get; set; }
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
