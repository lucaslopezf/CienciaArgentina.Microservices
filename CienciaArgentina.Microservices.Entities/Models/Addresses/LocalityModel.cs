﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.Addresses
{
    public class Locality : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
    }
}
