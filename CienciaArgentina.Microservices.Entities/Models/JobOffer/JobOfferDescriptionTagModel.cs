﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.JobOffer
{
    public class JobOfferDescriptionTag : EntityDateModel
    {
        public int Id { get; set; }
        public Tag Tag { get; set; }
    }
}
