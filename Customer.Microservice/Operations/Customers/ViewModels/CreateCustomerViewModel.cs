using System;
using Customer.Microservice.Entities;

namespace Customer.Microservice.Operations.Customer.ViewModels {

    public class CreateCustomerViewModel {
       
        public string Name { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }

}