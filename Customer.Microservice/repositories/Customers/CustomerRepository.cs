using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Customer.Microservice.Repositories.Customer.DtoModels;
using Customer.Microservice.Data;
using Microsoft.EntityFrameworkCore;

namespace Customer.Microservice.Repositories.Customer {

    public class CustomerRepository : ICustomerRepository {
        private readonly IApplicationDbContext _context;
        
        public CustomerRepository(
            IApplicationDbContext context
        ){
            _context = context;
        }

        public async Task<CustomerDtoModel> Create(CustomerDtoModel customer)
        {
           await _context.Customers.AddAsync(customer);
           await _context.SaveChanges();

           return customer;
        }

        public async Task<int> DeleteAsync(int id)
        {
           var dto = _context.Customers.FirstOrDefault(x => x.Id == id);
            _context.Customers.Remove(dto);
            await _context.SaveChanges();

            return id;
        }

        public async Task<IEnumerable<CustomerDtoModel>> GetAllAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            
            return customers;
        }

        public async Task<CustomerDtoModel> GetSingleAsync(int id)
        {
            var customer =  await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }

        public async Task<CustomerDtoModel> UpdateAsync(CustomerDtoModel customer)
        {
            Contract.Requires(customer != null);
            var dto = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);
            dto = customer;
            await _context.SaveChanges();

            return customer;
        }
    }

}
