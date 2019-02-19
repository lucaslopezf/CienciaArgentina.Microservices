using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class LaboratoryResearchLine : EntityDateModel
    {
        public Laboratory Laboratory { get; set; }
        public ResearchLine ResearchLine { get; set; }
    }
}
