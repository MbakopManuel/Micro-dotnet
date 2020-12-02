using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Microservice.Repositories.User.DtoModels;

namespace User.Microservice.Repositories.User {

    public interface IUserRepository{

        Task<IEnumerable<UserDtoModel>> GetAllAsync();

        Task<UserDtoModel> GetSingleAsync(int id);

        Task<UserDtoModel> Create(UserDtoModel user);

        Task<UserDtoModel> UpdateAsync(UserDtoModel user);

        Task<int> DeleteAsync(int id);

    }

}