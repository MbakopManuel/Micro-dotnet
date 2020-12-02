using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Microservice.Services.User.DomainModels;
using User.Microservice.Repositories.User.DtoModels;
using User.Microservice.Services.User;
using User.Microservice.Repositories.User;


namespace User.Microservice.Services.User {

    public class UserService : IUserService {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository UserRepository, IMapper mapper) {
            _userRepository = UserRepository;
            _mapper = mapper;
        }
        

        public async Task<UserDomainModel> CreateUserAsync(UserDomainModel User)
        {
            var dto = await _userRepository.Create(_mapper.Map<UserDtoModel>(User));
            return _mapper.Map<UserDomainModel>(dto);
        }

        public async Task<int> DeleteUserAsync(int id) => await _userRepository.DeleteAsync(id);

        public async Task<IEnumerable<UserDomainModel>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDomainModel>>(users);
        }

        public async Task<UserDomainModel> GetUserAsync(int id)
        {
            var user = await _userRepository.GetSingleAsync(id);
            return _mapper.Map<UserDomainModel>(user);
        }

        public async Task<UserDomainModel> UpdateUserAsync(UserDomainModel User)
        {
            var dto = await _userRepository.UpdateAsync(_mapper.Map<UserDtoModel>(User));
            return _mapper.Map<UserDomainModel>(dto);
        }
    }

}