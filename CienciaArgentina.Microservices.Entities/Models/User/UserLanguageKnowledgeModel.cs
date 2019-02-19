using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.User
{
    public class UserLanguageKnowledge : BaseModel
    {
        public UserLanguage UserLanguage { get; set; }
        public UserLanguageSkill UserLanguageSkill { get; set; }
        public UserData UserData { get; set; }
    }
}
