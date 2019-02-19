using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.Institutes
{
    public class ResearchLine : EntityDateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // TODO: Add papers
    }
}
