using System;
using SampleAuth.Microservice.Entities;

namespace SampleAuth.Microservice.Operations.User.ViewModels {

    public class LoginUserViewModel {
       
        public string Phone { get; set; }
        public string Password { get; set; }
    }

}