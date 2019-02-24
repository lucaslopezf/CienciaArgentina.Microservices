using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Entities.Models.Organizations
{
    public class OrganizationProject : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string ExperimentalModel { get; set; }
        public UserProfile Responsable { get; set; }
    }
}
