﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models.Institutes;

namespace CienciaArgentina.Microservices.Entities.Models.Institutes
{
    public class LaboratoryResearchLine : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public Laboratory Laboratory { get; set; }
        public ResearchLine ResearchLine { get; set; }
    }
}
