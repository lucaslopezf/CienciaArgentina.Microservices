﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.User
{
    public class UserLanguage : BaseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
