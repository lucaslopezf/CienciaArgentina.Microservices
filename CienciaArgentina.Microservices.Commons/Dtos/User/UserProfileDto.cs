﻿using System;

namespace CienciaArgentina.Microservices.Commons.Dtos.User
{
    public class UserProfileDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Identifier { get; set; }
        public SocialNetworkDto SocialNetwork { get; set; }
        public UserOrganizationDto UserOrganization { get; set; }
        public int Sex { get; set; }
        public AddressDto Address { get; set; }
        public DateTime Birthday { get; set; }
        public AccountDto AccountDto { get; set; }
    }
}
