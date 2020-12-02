using System;
using System.ComponentModel.DataAnnotations.Schema;
using User.Microservice.Entities;
using User.Microservice.Repositories.Role.DtoModels;
namespace User.Microservice.Repositories.User.DtoModels {

    public class UserDtoModel : BaseEntity {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Created_at { get; set;}
        public int Role_id { get; set;}
        public RoleDtoModel Role {get; set;}

    }

}