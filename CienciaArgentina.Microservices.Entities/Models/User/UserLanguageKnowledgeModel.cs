﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.User
{
    public class UserLanguageKnowledge : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public UserLanguage UserLanguage { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
