using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleAuth.Microservice.Services.Role.DomainModels;

namespace SampleAuth.Microservice.Services.Role {

    public interface IRoleService{


        Task<IEnumerable<RoleDomainModel>> GetAllRolesAsync();

        Task<RoleDomainModel> GetRoleAsync(int id);

        Task<RoleDomainModel> CreateRoleAsync(RoleDomainModel Role);

        Task<RoleDomainModel> UpdateRoleAsync(RoleDomainModel Role);

        Task<int> DeleteRoleAsync(int id);

    }

}