using System;
using SampleAuth.Microservice.Entities;
using SampleAuth.Microservice.Operations.Role.ViewModels;

namespace SampleAuth.Microservice.Operations.User.ViewModels {

    public class RefreshTokenUserViewModel : BaseEntity {
       
       
        public string RefreshToken { get; set; }
    }

}