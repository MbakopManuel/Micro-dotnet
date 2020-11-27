using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Microservice.Repositories.Customer.DtoModels;

namespace Customer.Microservice.Repositories.Customer {

    public interface ICustomerRepository{

        Task<IEnumerable<CustomerDtoModel>> GetAllAsync();

        Task<CustomerDtoModel> GetSingleAsync(int id);

        Task<CustomerDtoModel> Create(CustomerDtoModel customer);

        Task<CustomerDtoModel> UpdateAsync(CustomerDtoModel customer);

        Task<int> DeleteAsync(int id);

    }

}