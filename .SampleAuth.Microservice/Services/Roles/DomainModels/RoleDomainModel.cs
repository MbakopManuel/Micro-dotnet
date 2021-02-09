using System;
using SampleAuth.Microservice.Entities;
namespace SampleAuth.Microservice.Services.Role.DomainModels{

    public class RoleDomainModel : BaseEntity {
        public string Name { get; set; }
        public int Created_at {get; set;}
    }

}