using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models.User;
using CienciaArgentina.Microservices.Entities.Models.Commons;
using CienciaArgentina.Microservices.Entities.Models.Organizations;
using CienciaArgentina.Microservices.Entities.Models.Addresses;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Commons.Dtos.Organization;
using CienciaArgentina.Microservices.Entities.Models.JobOffer;

namespace CienciaArgentina.Microservices.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserCreateDto>().ReverseMap();
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            CreateMap<SocialNetwork, SocialNetworkDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<OrganizationType, OrganizationTypeDto>().ReverseMap();
            CreateMap<Position, PositionDto>().ReverseMap();
            CreateMap<UserOrganization, UserOrganizationDto>().ReverseMap();
            CreateMap<JobOfferDto, JobOffer>();
        }
    }
}
