using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Data;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Data.Repositories;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

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
            //Add DbContext and interfaces
            services.AddDbContext<CienciaArgentinaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();

            //TODO Take version and title from config
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "Ciencia Argentina Microservices", Version = "v1" });
            });

            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddMvc(config =>
                {
                    config.ReturnHttpNotAcceptable = true;
                    config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                    config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseCienciaArgMiddleware();
            app.UseHttpsRedirection();

            app.UseApiVersioning();
            app.UseSwagger();

            //TODO: Get url and name from appsettings
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Ciencia Argentina Microservices");
            });

            AutoMapper.Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<User, UserCreateDto>().ReverseMap();
            });
            app.UseMvc();
        }
    }
}
