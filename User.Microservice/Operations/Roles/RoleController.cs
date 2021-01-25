using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Microservice.Data;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Services.Role;
using User.Microservice.Services.Role.DomainModels;
using User.Microservice.Operations.Role.ViewModels;
using User.Microservice.Operations.Role.Validator;
using AutoMapper;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Authorization;
using JWTAuthentication.Models;

namespace User.Microservice.Operations
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.Admin)]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(
            IMapper mapper,
            IRoleService roleService
        )
        {
            _roleService = roleService;
            _mapper = mapper;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [HttpPost]
        public async Task<ActionResult<RoleViewModel>> Create([FromBody] CreateRoleViewModel viewModel)
        {

            var validator = new CreateRoleValidator();

            var validate = validator.Validate(viewModel);

            if(!validate.IsValid){
                return HandleErrorResponse(HttpStatusCode.BadRequest, validate.ToString());
            }

            var role = _mapper.Map<RoleDomainModel>(viewModel);

            // create new role
            var createdRole = await _roleService.CreateRoleAsync(role);

            // prepare response
            var response = _mapper.Map<RoleViewModel>(createdRole);

            return HandleCreatedResponse(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [HttpGet]
        public async Task<ActionResult<List<RoleViewModel>>> GetAll()
        {
            var roles = await _roleService.GetAllRolesAsync();

            var response = _mapper.Map<List<RoleViewModel>>(roles);

            return HandleSuccessResponse(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewModel>> GetById(int id)
        {
             var role = await _roleService.GetRoleAsync(id);
            if(role == null){
                return HandleErrorResponse(HttpStatusCode.NotFound, "role doesn't exist");
            }
            var response = _mapper.Map<RoleViewModel>(role);

            return HandleSuccessResponse(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // delete existing movie
            await _roleService.DeleteRoleAsync(id);

            return HandleDeletedResponse();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [HttpPut("{id}")]
        public async Task<ActionResult<RoleViewModel>> Update(int id, [FromBody] RoleViewModel viewModel)
        {
            Contract.Requires(viewModel != null);
           
            // id can be in URL, body, or both
            viewModel.Id = id;

            // map view model to domain model
            var role = _mapper.Map<RoleDomainModel>(viewModel);

            // update existing role
            var updatedrole = await _roleService.UpdateRoleAsync(role);

            // prepare response
            var response = _mapper.Map<RoleViewModel>(updatedrole);

            // 200 response
            return HandleSuccessResponse(response);
        }
    }
}