using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AutoMapper;

using User.Microservice.Repositories.Weather;
using User.Microservice.Services.Weather;
using User.Microservice.Operations.Weather.MapperProfiles;
using User.Microservice.Services.Weather.MapperProfiles;

using User.Microservice.Repositories.User;
using User.Microservice.Services.User;
using User.Microservice.Operations.User.MapperProfiles;
using User.Microservice.Services.User.MapperProfiles;

using User.Microservice.Repositories.Role;
using User.Microservice.Services.Role;
using User.Microservice.Operations.Role.MapperProfiles;
using User.Microservice.Services.Role.MapperProfiles;


namespace User.Microservice.Services {


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