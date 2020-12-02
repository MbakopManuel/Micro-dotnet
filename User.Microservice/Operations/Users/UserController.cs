using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Microservice.Data;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Services.User;
using User.Microservice.Services.User.DomainModels;
using User.Microservice.Operations.User.ViewModels;
using User.Microservice.Operations.User.Validator;
using AutoMapper;
using System.Diagnostics.Contracts;

namespace User.Microservice.Operations
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(
            IMapper mapper,
            IUserService userService
        )
        {
            _userService = userService;
            _mapper = mapper;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Create([FromBody] CreateUserViewModel viewModel)
        {

            var validator = new CreateUserValidator();

            var validate = validator.Validate(viewModel);

            if(!validate.IsValid){
                return HandleErrorResponse(HttpStatusCode.BadRequest, validate.ToString());
            }

            var user = _mapper.Map<UserDomainModel>(viewModel);

            // create new user
            var createdUser = await _userService.CreateUserAsync(user);

            // prepare response
            var response = _mapper.Map<UserViewModel>(createdUser);

            return HandleCreatedResponse(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();

            var response = _mapper.Map<List<UserViewModel>>(users);

            return HandleSuccessResponse(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
             var user = await _userService.GetUserAsync(id);

            var response = _mapper.Map<UserViewModel>(user);

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
            await _userService.DeleteUserAsync(id);

            return HandleDeletedResponse();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   
        [HttpPut("{id}")]
        public async Task<ActionResult<UserViewModel>> Update(int id, [FromBody] UserViewModel viewModel)
        {
            Contract.Requires(viewModel != null);
           
            // id can be in URL, body, or both
            viewModel.Id = id;

            // map view model to domain model
            var user = _mapper.Map<UserDomainModel>(viewModel);

            // update existing user
            var updateduser = await _userService.UpdateUserAsync(user);

            // prepare response
            var response = _mapper.Map<UserViewModel>(updateduser);

            // 200 response
            return HandleSuccessResponse(response);
        }
    }
}