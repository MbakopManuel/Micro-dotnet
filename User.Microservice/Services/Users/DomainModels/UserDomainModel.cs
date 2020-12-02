using System;
using User.Microservice.Entities;
using User.Microservice.Services.Role.DomainModels;
namespace User.Microservice.Services.User.DomainModels{

    public class UserDomainModel : BaseEntity {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Created_at { get; set;}
        public int Role_id { get; set;}
        public RoleDomainModel Role {get; set;}
    }

}