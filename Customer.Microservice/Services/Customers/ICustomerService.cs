using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Microservice.Services.Customer.DomainModels;

namespace Customer.Microservice.Services.Customer {

    public interface ICustomerService{


        Task<IEnumerable<CustomerDomainModel>> GetAllCustomersAsync();

        Task<CustomerDomainModel> GetCustomerAsync(int id);

        Task<CustomerDomainModel> CreateCustomerAsync(CustomerDomainModel Customer);

        Task<CustomerDomainModel> UpdateCustomerAsync(CustomerDomainModel Customer);

        Task<int> DeleteCustomerAsync(int id);

    }

}