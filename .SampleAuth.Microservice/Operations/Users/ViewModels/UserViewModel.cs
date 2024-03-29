using System;
using SampleAuth.Microservice.Entities;
using SampleAuth.Microservice.Operations.Role.ViewModels;

namespace SampleAuth.Microservice.Operations.User.ViewModels {

    public class UserViewModel : BaseEntity {
       
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public string Address { get; set; }
        public int Created_at { get; set;}
        public string? Token {get; set;}
        public RoleViewModel Role {get; set;}
    }

}