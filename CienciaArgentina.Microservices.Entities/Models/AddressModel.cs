﻿using System;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string Department { get; set; }
        public string Additionals { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
