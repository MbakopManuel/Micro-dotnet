using System;
using User.Microservice.Entities;

namespace User.Microservice.Operations.User.ViewModels {

    public class CreateUserViewModel {
       
       public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }

}