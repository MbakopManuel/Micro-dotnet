using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAuth.Microservice.Repositories.User.DtoModels;
using SampleAuth.Microservice.Repositories.Role.DtoModels;

namespace SampleAuth.Microservice.Data
{
    public interface IApplicationDbContext
    {
        /** Begin Interface DBContext Adding */

            DbSet<UserDtoModel> Users{ get; set; }
            DbSet<RoleDtoModel> Roles{ get; set; }
        
        /** End Interface DBContext Adding */
        Task<int> SaveChanges();
    }
}
