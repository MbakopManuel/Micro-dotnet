using FluentValidation;
using Customer.Microservice.Operations.Customer.ViewModels;

namespace Customer.Microservice.Operations.Customer.Validator{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerViewModel> {
        public CreateCustomerValidator() {

            RuleFor(customer => customer.Name)
                    .NotEmpty()
                    .NotNull();
            
            RuleFor(customer => customer.City)
                    .NotEmpty()
                    .NotNull();
            
            RuleFor(customer => customer.Contact)
                    .NotEmpty()
                    .NotNull();
            
            RuleFor(customer => customer.Email)
                    .NotEmpty()
                    .NotNull();
            
        }


    }
}