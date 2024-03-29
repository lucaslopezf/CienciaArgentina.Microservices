﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models.Commons;
using CienciaArgentina.Microservices.Entities.Models.Organizations;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Entities.Models.User
{
    public class UserOrganization : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public Organization Organization { get; set; }
        public Position Position { get; set; }

        //For identity
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
