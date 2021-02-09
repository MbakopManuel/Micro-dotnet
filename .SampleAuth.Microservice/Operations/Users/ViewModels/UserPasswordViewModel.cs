using System;
using System.Collections.Generic;
using SampleAuth.Microservice.Entities;

namespace SampleAuth.Microservice.Operations.User.ViewModels {

    public class UserPasswordViewModel : BaseEntity {
       
        public string odlpassword { get; set; }
        public string newpassword { get; set; }
    }

}