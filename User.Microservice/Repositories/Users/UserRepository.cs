using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using User.Microservice.Repositories.User.DtoModels;
using User.Microservice.Data;
using Microsoft.EntityFrameworkCore;

namespace User.Microservice.Repositories.User {

    public class UserRepository : IUserRepository {
        private readonly IApplicationDbContext _context;
        
        public UserRepository(
            IApplicationDbContext context
        ){
            _context = context;
        }

        public async Task<UserDtoModel> Create(UserDtoModel user)
        {
           await _context.Users.AddAsync(user);
           await _context.SaveChanges();

           return user;
        }

        public async Task<int> DeleteAsync(int id)
        {
           var dto = _context.Users.FirstOrDefault(x => x.Id == id);
            _context.Users.Remove(dto);
            await _context.SaveChanges();

            return id;
        }

        public async Task<IEnumerable<UserDtoModel>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            
            return users;
        }

        public async Task<UserDtoModel> GetSingleAsync(int id)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<UserDtoModel> UpdateAsync(UserDtoModel user)
        {
            Contract.Requires(user != null);
            var dto = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            dto = user;
            await _context.SaveChanges();

            return user;
        }
    }

}
