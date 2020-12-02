using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Microservice.Services.User.DomainModels;

namespace User.Microservice.Services.User {

    public interface IUserService{


        Task<IEnumerable<UserDomainModel>> GetAllUsersAsync();

        Task<UserDomainModel> GetUserAsync(int id);

        Task<UserDomainModel> CreateUserAsync(UserDomainModel User);

        Task<UserDomainModel> UpdateUserAsync(UserDomainModel User);

        Task<int> DeleteUserAsync(int id);

    }

}