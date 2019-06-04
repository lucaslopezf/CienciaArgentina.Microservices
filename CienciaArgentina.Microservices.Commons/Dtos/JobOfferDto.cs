using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CienciaArgentina.Microservices.Commons.Dtos.Organization;
using CienciaArgentina.Microservices.Entities.Models.Addresses;
using CienciaArgentina.Microservices.Entities.Models.JobOffer;
using CienciaArgentina.Microservices.Entities.Models.Organizations;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Commons.Dtos
{
    public class JobOfferDto
    {
        public DepartmentDto Department { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
        //public Address Address { get; set; }
        public bool Experience { get; set; } //TODO: Enum
        public string JobType { get; set; }
        public string AcademicRequirements { get; set; }
        public string ResearchTopics { get; set; }
        public string ExperimentalModel { get; set; }
        public DateTime DurationOffer { get; set; }
        public bool PresentationLetter { get; set; }
        public string CareerState { get; set; } //Si tiene que estar finalizada la carrera, etc.
        public DateTime DateCareerFinish { get; set; } //Tiene que terminar la carrera antes de..
        public string ProjectManager { get; set; } //Responsable del proyecto
        public string ContactEmail { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
