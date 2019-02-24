using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.User
{
    public class UserCv : BaseModel
    {
        [Key]
        public int Id { get; set; }
        //public UserStudy UserStudy { get; set; }
        //public WorkExperience WorkExperience { get; set; }
        public string UrlCv { get; set; }
        //public UserData UserProfile { get; set; }
    }
}
