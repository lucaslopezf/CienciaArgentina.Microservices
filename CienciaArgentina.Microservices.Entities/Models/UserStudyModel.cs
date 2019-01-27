using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserStudy
    {
        public int Id { get; set; }
        public UserStudyTypes IdType { get; set; }
        public string Carrer { get; set; }
        public string Institution { get; set; }
        public University IdUniversity { get; set; }
        public UserData IdUserData { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
