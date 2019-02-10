using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Data;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Data.Repositories;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Middlewares;
using CienciaArgentina.Microservices.Storage.Azure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
            //Add DbContext and connectionString
            services.AddDbContext<CienciaArgentinaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            //Authentication
            services.AddIdentity<ApplicationUser, IdentityRole>()
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
                        ValidIssuer = "cienciaargentina.com",
                        ValidAudience = "cienciaargentina.com",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["apiSecretKey"])),
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //TODO: Stacktrace
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "text/html";
                        var exception = context.Features.Get<IExceptionHandlerFeature>();
                        Guid guid = Guid.NewGuid();
                        var message = "Error en la aplicación";
                        if (exception != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global exception logger");
                            message = $"Error: {exception.Error.Message}." +
                                      $"Id: {guid}";
                            logger.LogError(context.Response.StatusCode, exception.Error, message);
                           
                        }
                        
                        await context.Response.WriteAsync(message);


                    });
                });
                
                // SSL
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseCienciaArgMiddleware();
            app.UseHttpsRedirection();
            FullStorageInitializer.Initialize();
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
            });

            //Use authentication
            app.UseAuthentication();
            FullStorageInitializer.Initialize();
            app.UseMvc();
        }
    }
}
