using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Microservice.Data;
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



using Sample.Microservice.Services;
namespace Sample.Microservice
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
                options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")
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
                    Title = "Sample Microservice API",
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
                

            });
            #endregion
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddControllers();
            services.AddMvc().AddFluentValidation();
        }

            //ajouter les profiles de mapper
         private static IEnumerable<Profile> GetAssemblyNamesToScanForMapperProfiles(){
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

            app.UseRouting();

            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseCors();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample.Microservice");
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

        private static void  addServive(IServiceCollection services){
            var serv = new Service(services);
            serv.addService();
        }
    }
}
