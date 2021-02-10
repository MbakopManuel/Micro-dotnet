using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAuth.Microservice.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;

using SampleAuth.Microservice.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JWTAuthentication.Models;
namespace SampleAuth.Microservice
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
            CorsConfiguration(services);
            services.AddDbContextPool<ApplicationDbContext>(
                options => options.UseMySql("server=localhost;port=3306;database=FalconFx;user=tp_db_user;password=(T0ntine!19)"
                ));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            //services et repository
            addServive(services);

            services.AddAutoMapper(GetAssemblyNamesToScanForMapperProfiles());

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "User Microservice API",
                });

                c.MapType<TimeSpan>(() => new OpenApiSchema { Type = "string", Format = "d.hh:mm:ss" });

                c.MapType<TimeSpan?>(() => new OpenApiSchema { Type = "string", Format = "d.hh:mm:ss" });

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

            });
            #endregion

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddControllers();
            services.AddMvc().AddFluentValidation();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "http://localhost:44373/",
                            ValidAudience = "http://localhost:44373/",
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("322e9998-f1f0-494a-9b9d-aea4e0008888")),
                            ClockSkew = TimeSpan.Zero
                        };
                    });
            services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
            });
        }

        //ajouter les profiles de mapper
        private static IEnumerable<Profile> GetAssemblyNamesToScanForMapperProfiles()
        {
            var serv = new Service();
            var profiles = serv.addProfile();
            return profiles;
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseCors();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleAuth.Microservice");
                c.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private static void CorsConfiguration(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowSpecificOrigin",
                    builder => builder.AllowAnyOrigin() // TODO: Replace with FE Service Host as appropriate to constrain clients
                        .AllowAnyHeader()
                        .WithMethods("PUT", "POST", "OPTIONS", "GET", "DELETE"));
            });
        }

        private static void addServive(IServiceCollection services)
        {
            var serv = new Service(services);
            serv.addService();
        }
    }
}
