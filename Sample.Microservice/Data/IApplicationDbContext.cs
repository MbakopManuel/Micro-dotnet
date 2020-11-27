using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Microservice.Repositories.Sample.DtoModels;

namespace Sample.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<SampleDtoModel> Samples{ get; set; }
        Task<int> SaveChanges();
    }
}
