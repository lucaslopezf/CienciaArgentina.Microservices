using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.AutoMapper;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Commons.Dtos.Organization;
using CienciaArgentina.Microservices.Controllers;
using CienciaArgentina.Microservices.Entities.Models.JobOffer;
using CienciaArgentina.Microservices.Repositories.IUoW;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CienciaArgentina.Microservices.Tests.Application.Microservices.Controllers
{
    public class JobOffersControllerTests
    {
        public class PostMethod
        {
            [Fact(Skip = "Still not working as it should be")]
            public async Task Post_ReturnsOfferId()
            {
                var uof = new Mock<IUnitOfWork>();

                var mappingConfig = new MapperConfiguration(map => { map.AddProfile(new MappingProfile()); });
                var mapper = mappingConfig.CreateMapper();

                var controller = new JobOffersController(uof.Object, mapper);

                var tag = new List<Tag>();
                tag.Add(new Tag() {Description = "test", DateCreated = DateTime.Now});
                var jobOffer = new JobOfferDto()
                {
                    AcademicRequirements = "Test",
                    CareerState = "Test",
                    ContactEmail = "test@test.com",
                    DateCareerFinish = DateTime.Now,
                    Department = new DepartmentDto() { Address = new AddressDto() { StreetName = "test", StreetNumber = "test", LocalityId = 1, ZipCode = "1512", Department = "asdasd", Additionals = null} },
                    Description = "Test",
                    DurationOffer = DateTime.Now,
                    Experience = false,
                    ExperimentalModel = "Test",
                    //JobType = 1,
                    PresentationLetter = false,
                    ProjectManager = "Test",
                    ResearchTopics = "Test",
                    Salary = (decimal) 1.0,
                    //Tags = tag,
                    Title = "Test"
                };
                
                var result = await controller.Post(jobOffer);
                var okResult = result as OkObjectResult;
                Assert.NotNull(okResult);
                Assert.Equal(200, okResult.StatusCode);
            }
        }
    }
}
