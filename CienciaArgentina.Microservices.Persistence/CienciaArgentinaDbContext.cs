using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models.Addresses;
using CienciaArgentina.Microservices.Entities.Models.Commons;
using CienciaArgentina.Microservices.Entities.Models.JobOffer;
using CienciaArgentina.Microservices.Entities.Models.Organizations;
using CienciaArgentina.Microservices.Entities.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CienciaArgentina.Microservices.Persistence
{
    public class CienciaArgentinaDbContext : IdentityDbContext<ApplicationUser>
    {
        public CienciaArgentinaDbContext(DbContextOptions<CienciaArgentinaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        public DbSet<UserData> UsersData { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<UserStudyType> UserStudyTypes { get; set; }
        public DbSet<UserStudy> UserStudies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserDepartment> UserDepartments { get; set; }
        public DbSet<UserOrganization> UserOrganizations { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserStudyCompletion> UserStudiesCompletion { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<OrganizationProject> OrganizationProjects { get; set; }
        public DbSet<DepartmentProject> DepartmentProjects { get; set; }
        public DbSet<JobOffer> JobOffer { get; set; }
        public DbSet<JobReferral> JobReferrals { get; set; }
        public DbSet<JobOfferCandidateReferral> JobOfferCandidateReferrals { get; set; }
        public DbSet<JobOfferCandidate> JobOfferCandidates { get; set; }
        public DbSet<JobOfferDescriptionTag> JobOfferDescriptionTags { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<JobOfferUserLanguajeKnoweldge> JobOfferUserLanguajeKnoweldge { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<UserLanguageKnowledge> UserLanguagesKnowledge { get; set; }
        public DbSet<UserLanguageSkill> UserLanguagesSkill { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
    }
}
