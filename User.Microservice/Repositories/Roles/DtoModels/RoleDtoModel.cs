using System;
using User.Microservice.Entities;

namespace User.Microservice.Repositories.Role.DtoModels {

    public class RoleDtoModel : BaseEntity {
       
        
        public string Name { get; set; }
        public int Created_at {get; set;}
    }

}