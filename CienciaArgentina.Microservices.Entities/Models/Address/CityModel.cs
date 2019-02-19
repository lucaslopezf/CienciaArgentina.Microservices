using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class City : EntityDateModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public State State { get; set; }

    }
}
