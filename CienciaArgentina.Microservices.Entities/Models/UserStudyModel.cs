using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserStudy
    {
        [Key]
        public int Id { get; set; }
        public UserStudyType UserStudyType { get; set; }
        public string Carrer { get; set; }
        public string Institution { get; set; }
        public string Additional { get; set; }
        public University University { get; set; }
        public int? ApprovedSubjects { get; set; }
        public int? TotalSubjects { get; set; }
        public UserStudyCompletion UserStudyCompletion { get; set; }
        public UserData UserData { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
