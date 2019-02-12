﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class EntityDateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }

        public EntityDateModel()
        {
            DateCreated = DateTime.Now;
            DateDeleted = null;
        }
    }
}
