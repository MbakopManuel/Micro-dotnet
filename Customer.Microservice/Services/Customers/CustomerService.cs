using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Microservice.Services.Customer.DomainModels;
using Customer.Microservice.Repositories.Customer.DtoModels;
using Customer.Microservice.Services.Customer;
using Customer.Microservice.Repositories.Customer;


namespace Customer.Microservice.Services.Customer {

    public class CustomerService : ICustomerService {

        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository CustomerRepository, IMapper mapper) {
            _customerRepository = CustomerRepository;
            _mapper = mapper;
        }
        

        public async Task<CustomerDomainModel> CreateCustomerAsync(CustomerDomainModel Customer)
        {
            var dto = await _customerRepository.Create(_mapper.Map<CustomerDtoModel>(Customer));
            return _mapper.Map<CustomerDomainModel>(dto);
        }

        public async Task<int> DeleteCustomerAsync(int id) => await _customerRepository.DeleteAsync(id);

        public async Task<IEnumerable<CustomerDomainModel>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<List<CustomerDomainModel>>(customers);
        }

        public async Task<CustomerDomainModel> GetCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetSingleAsync(id);
            return _mapper.Map<CustomerDomainModel>(customer);
        }

        public async Task<CustomerDomainModel> UpdateCustomerAsync(CustomerDomainModel Customer)
        {
            var dto = await _customerRepository.UpdateAsync(_mapper.Map<CustomerDtoModel>(Customer));
            return _mapper.Map<CustomerDomainModel>(dto);
        }
    }

}