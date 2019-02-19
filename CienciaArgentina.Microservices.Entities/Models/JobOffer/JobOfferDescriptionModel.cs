using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class JobOfferDescriptionModel : EntityDateModel
    {
        [Key]
        public int Id { get; set; }

        public bool Experience { get; set; }
        public bool PresentationLetter { get; set; }
        public string CareerState { get; set; } //Si tiene que estar finalizada la carrera, etc.
        public DateTime DateCareerFinish { get; set; } //Tiene que terminar la carrera antes de..
        public string ProjectManager { get; set; } //Responsable del proyecto
        public string ContactEmail { get; set; }
    }
}
