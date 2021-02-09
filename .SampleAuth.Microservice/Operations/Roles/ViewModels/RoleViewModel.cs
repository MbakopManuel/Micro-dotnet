using System;
using SampleAuth.Microservice.Entities;

namespace SampleAuth.Microservice.Operations.Role.ViewModels {

    public class RoleViewModel : BaseEntity {
       
       
        public string Name { get; set; }
        public int Created_at {get; set;}
    }

}