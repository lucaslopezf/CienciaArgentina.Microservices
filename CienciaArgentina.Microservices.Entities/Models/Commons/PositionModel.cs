using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class Position : EntityDateModel
    {
        [Key]
        public int Id { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
    }
}
