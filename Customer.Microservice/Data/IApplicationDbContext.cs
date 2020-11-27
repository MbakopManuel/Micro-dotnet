using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Microservice.Repositories.Customer.DtoModels;

namespace Customer.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<CustomerDtoModel> Customers{ get; set; }
        Task<int> SaveChanges();
    }
}
