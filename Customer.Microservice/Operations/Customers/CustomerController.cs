using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Microservice.Data;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Customer.Microservice.Services.Customer;
using Customer.Microservice.Services.Customer.DomainModels;
using Customer.Microservice.Operations.Customer.ViewModels;
using Customer.Microservice.Operations.Customer.Validator;
using AutoMapper;
using System.Diagnostics.Contracts;

namespace Customer.Microservice.Operations
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(
            IMapper mapper,
            ICustomerService customerService
        )
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> Create([FromBody] CreateCustomerViewModel viewModel)
        {

            var validator = new CreateCustomerValidator();

            var validate = validator.Validate(viewModel);

            if(!validate.IsValid){
                return HandleErrorResponse(HttpStatusCode.BadRequest, validate.ToString());
            }

            var customer = _mapper.Map<CustomerDomainModel>(viewModel);

            // create new customer
            var createdCustomer = await _customerService.CreateCustomerAsync(customer);

            // prepare response
            var response = _mapper.Map<CustomerViewModel>(createdCustomer);

            return HandleCreatedResponse(response);
        }


        [HttpGet]
        public async Task<ActionResult<List<CustomerViewModel>>> GetAll()
        {
            var customers = await _customerService.GetAllCustomersAsync();

            var response = _mapper.Map<List<CustomerViewModel>>(customers);

            return HandleSuccessResponse(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerViewModel>> GetById(int id)
        {
             var customer = await _customerService.GetCustomerAsync(id);

            var response = _mapper.Map<CustomerViewModel>(customer);

            return HandleSuccessResponse(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // delete existing movie
            await _customerService.DeleteCustomerAsync(id);

            return HandleDeletedResponse();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerViewModel>> Update(int id, [FromBody] CustomerViewModel viewModel)
        {
            Contract.Requires(viewModel != null);
           
            // id can be in URL, body, or both
            viewModel.Id = id;

            // map view model to domain model
            var customer = _mapper.Map<CustomerDomainModel>(viewModel);

            // update existing customer
            var updatedcustomer = await _customerService.UpdateCustomerAsync(customer);

            // prepare response
            var response = _mapper.Map<CustomerViewModel>(updatedcustomer);

            // 200 response
            return HandleSuccessResponse(response);
        }
    }
}