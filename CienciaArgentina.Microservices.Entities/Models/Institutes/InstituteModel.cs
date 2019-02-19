﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models.Addresses;

namespace CienciaArgentina.Microservices.Entities.Models.Institutes
{
    public class Institute : EntityDateModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string DescriptionLarge { get; set; }
        public string Link { get; set; }
        public Address Address { get; set; }
    }
}
