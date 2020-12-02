using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Microservice.Repositories.User.DtoModels;
using User.Microservice.Repositories.Role.DtoModels;

namespace User.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<UserDtoModel> Users{ get; set; }
        DbSet<RoleDtoModel> Roles{ get; set; }
        Task<int> SaveChanges();
    }
}
