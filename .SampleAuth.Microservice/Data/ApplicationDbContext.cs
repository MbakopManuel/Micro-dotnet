
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAuth.Microservice.Repositories.User.DtoModels;
using SampleAuth.Microservice.Repositories.Role.DtoModels;

namespace SampleAuth.Microservice.Data
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /** Begin DBContext Adding */
            
            DbSet<UserDtoModel> IApplicationDbContext.Users { get; set; }
            DbSet<RoleDtoModel> IApplicationDbContext.Roles { get; set; }

        /** End DBContext Adding */

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
