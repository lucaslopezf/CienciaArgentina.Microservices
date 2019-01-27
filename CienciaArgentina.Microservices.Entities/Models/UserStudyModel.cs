using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserStudy
    {
        [Key]
        public int IdUserStudy { get; set; }
        public UserStudyType IdUserStudyType { get; set; }
        public string Carrer { get; set; }
        public string Institution { get; set; }
        public string Additional { get; set; }
        public University IdUniversity { get; set; }
        public UserData IdUserData { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
