using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AutoMapper;

using SampleAuth.Microservice.Repositories.Weather;
using SampleAuth.Microservice.Services.Weather;
using SampleAuth.Microservice.Operations.Weather.MapperProfiles;
using SampleAuth.Microservice.Services.Weather.MapperProfiles;

using SampleAuth.Microservice.Repositories.User;
using SampleAuth.Microservice.Services.User;
using SampleAuth.Microservice.Operations.User.MapperProfiles;
using SampleAuth.Microservice.Services.User.MapperProfiles;

using SampleAuth.Microservice.Repositories.Role;
using SampleAuth.Microservice.Services.Role;
using SampleAuth.Microservice.Operations.Role.MapperProfiles;
using SampleAuth.Microservice.Services.Role.MapperProfiles;


namespace SampleAuth.Microservice.Services {


    public class Service{

        private readonly IServiceCollection _services;
        public Service(IServiceCollection services){
            _services = services;
           
        }

        public Service(){}

        public void addService(){
            _services.TryAddScoped<IWeatherRepository, WeatherRepository>();
            _services.TryAddTransient<IWeatherService, WeatherService>();
            
            _services.TryAddScoped<IUserRepository, UserRepository>();
            _services.TryAddTransient<IUserService, UserService>();


            _services.TryAddScoped<IRoleRepository, RoleRepository>();
            _services.TryAddTransient<IRoleService, RoleService>();
          
        }

        public IEnumerable<Profile> addProfile(){
            var profiles = new Profile[] { 
                new WeatherProfile(),
                new WeatherResponseProfile(),

                new UserProfile(),
                new LoginUserRequestProfile(),
                new UserResponseProfile(),
                new CreateUserRequestProfile(),
                new UpdateUserRequestProfile(),

                new RoleProfile(),
                new RoleResponseProfile(),
                new CreateRoleRequestProfile(),
                new UpdateRoleRequestProfile(),
             };

             return profiles;
        }
        

    }

}