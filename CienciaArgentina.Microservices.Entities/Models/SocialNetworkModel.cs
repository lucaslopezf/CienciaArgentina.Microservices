﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class SocialNetwork
    {
        [Key]
        public int Id { get; set; }
        public string SocialNetworkName { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public User User { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}