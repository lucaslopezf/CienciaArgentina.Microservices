﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class WorkExperience : EntityDateModel
    {
        [Key]
        public int Id { get; set; }

        public string Company { get; set; }
        public string Charge { get; set; }
        public string Description { get; set; }
        public string Addittions { get; set; }
        public Address Address { get; set; }
    }
}