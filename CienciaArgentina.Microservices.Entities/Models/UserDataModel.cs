﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserData
    {
        [Key]
        public int IdUserData { get; set; }

        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Sex IdSex { get; set; }
        public DateTime Birthday { get; set; }
        public string Identifier { get; set; }
        public Address IdAddress { get; set; }
        public Job IdJob { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
