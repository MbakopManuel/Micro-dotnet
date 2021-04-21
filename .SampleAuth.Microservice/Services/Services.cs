/** 
    This file is the file that make importations, injections dependancies, and profiles adding

 */

/** Begin Import */
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using AutoMapper;

    using SampleAuth.Microservice.Repositories.User;
    using SampleAuth.Microservice.Services.User;
    using SampleAuth.Microservice.Operations.User.MapperProfiles;
    using SampleAuth.Microservice.Services.User.MapperProfiles;

    using SampleAuth.Microservice.Repositories.Role;
    using SampleAuth.Microservice.Services.Role;
    using SampleAuth.Microservice.Operations.Role.MapperProfiles;
    using SampleAuth.Microservice.Services.Role.MapperProfiles;

/* End Import */


namespace SampleAuth.Microservice.Services {


    public class Service{

        private readonly IServiceCollection _services;
        public Service(IServiceCollection services){
            _services = services;
        }

        public Service(){}

        public void addService(){

            /** Begin Injection  */
            
                _services.TryAddScoped<IUserRepository, UserRepository>();
                _services.TryAddTransient<IUserService, UserService>();


                _services.TryAddScoped<IRoleRepository, RoleRepository>();
                _services.TryAddTransient<IRoleService, RoleService>();
            
            /** End Injection */
          
        }

        public IEnumerable<Profile> addProfile(){
            var profiles = new Profile[] { 
                /** Begin Adding Profiles */

                    new UserProfile(),
                    new LoginUserRequestProfile(),
                    new UserResponseProfile(),
                    new CreateUserRequestProfile(),
                    new UpdateUserRequestProfile(),

                    new RoleProfile(),
                    new RoleResponseProfile(),
                    new CreateRoleRequestProfile(),
                    new UpdateRoleRequestProfile(),

                /** End Adding Profiles */
             };

             return profiles;
        }
        

    }

}