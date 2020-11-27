using System;
using Customer.Microservice.Entities;

namespace Customer.Microservice.Repositories.Customer.DtoModels {

    public class CustomerDtoModel : BaseEntity {
       
        public string Name { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }

}