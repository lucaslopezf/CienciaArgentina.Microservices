﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.Organizations
{
    public class OrganizationType : BaseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal PayPlatform { get; set; }
    }
}
