using System;
using System.Text;
using AutoMapper;
using CienciaArgentina.Microservices.AutoMapper;
using CienciaArgentina.Microservices.Commons.Helpers.OAuth2;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Middlewares;
using CienciaArgentina.Microservices.Persistence;
using CienciaArgentina.Microservices.Persistence.Interfaces;
using CienciaArgentina.Microservices.Persistence.Redis;
using CienciaArgentina.Microservices.Storage.Azure;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
                        options.User.RequireUniqueEmail = true;
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

            services.AddCors();
            
            //Config MVC
            services.AddMvc(config =>
                {
                    config.ReturnHttpNotAcceptable = true;
                    config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                    config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation();

            //Define cache
            services.Configure<RedisConfiguration>(Configuration.GetSection("Redis"));

            services.AddDistributedRedisCache(options =>
            {
                options.InstanceName = Configuration.GetValue<string>("Redis:Name");
                options.Configuration = Configuration.GetValue<string>("Redis:Host");
            });

            services.AddSingleton<ICache, Redis>();
            // Mapper
            //Mapper DTO -> Models
            var mappingConfig = new MapperConfiguration(map => { map.AddProfile(new MappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAuthentication()
                .AddGoogle(OAuth2Helper.GoogleOAuth2Options);
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
            app.UseCors(builder =>
                builder.WithOrigins(Configuration.GetValue<string>("Cors:Whitelist")));

            //TODO: Get url and name from appsettings
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Ciencia Argentina Microservices");
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
