using System;
using System.Text;
using CienciaArgentina.Microservices.Dtos;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.Models.Addresses;
using CienciaArgentina.Microservices.Entities.Models.Commons;
using CienciaArgentina.Microservices.Entities.Models.Organizations;
using CienciaArgentina.Microservices.Entities.Models.User;
using CienciaArgentina.Microservices.Middlewares;
using CienciaArgentina.Microservices.Persistence;
using CienciaArgentina.Microservices.Storage.Azure;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Scrutor;

namespace CienciaArgentina.Microservices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add DbContext and connectionString
            services.AddDbContext<CienciaArgentinaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Repositories
            services.Scan(scan => scan
                .FromExecutingAssembly()
                .FromApplicationDependencies(a => a.FullName.StartsWith("CienciaArgentina"))
                .AddClasses(publicOnly: true)
                .AsMatchingInterface((service, filter) =>
                    filter.Where(implementation => implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
                .WithScopedLifetime());
            //Authentication
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                    {
                        //options.Lockout.MaxFailedAccessAttempts = 5;
                        //options.SignIn.RequireConfirmedEmail = true;
                        //options.User.RequireUniqueEmail = true;
                    })
                .AddEntityFrameworkStores<CienciaArgentinaDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["ApiAuthJWT:Issuer"],
                        ValidAudience = Configuration["ApiAuthJWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["ApiAuthJWT:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    });

            //Api Documentation => Swagger
            //TODO Take version and title from config
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "Ciencia Argentina Microservices", Version = "v1" });
            });

            //ApiVersioning
            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            //Logging
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            //Config MVC
            services.AddMvc(config =>
                {
                    config.ReturnHttpNotAcceptable = true;
                    config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                    config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            // FluentValidator
            services.AddMvc().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseApiVersioning();
            app.UseSwagger();

            //TODO: Get url and name from appsettings
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Ciencia Argentina Microservices");
            });

            //Mapper DTO -> Models
            AutoMapper.Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<ApplicationUser, UserCreateDto>().ReverseMap();
                mapper.CreateMap<UserProfile, UserProfileDto>().ReverseMap();
                mapper.CreateMap<SocialNetwork, SocialNetworkDto>().ReverseMap();
                mapper.CreateMap<Address, AddressDto>().ReverseMap();
                mapper.CreateMap<Organization, OrganizationDto>().ReverseMap();
                mapper.CreateMap<Position, PositionDto>().ReverseMap();
                mapper.CreateMap<UserOrganization, UserOrganization>().ReverseMap();
            });

            //Use authentication
            app.UseAuthentication();

            //Initialize storage
            FullStorageInitializer.Initialize();

            //ExceptionHandler middleware
            app.UseExceptionMiddleware();

            //
            app.UseMvc();
        }
    }
}
