using FluentValidation;
using SampleAuth.Microservice.Operations.User.ViewModels;

namespace SampleAuth.Microservice.Operations.User.Validator{
    public class LoginUserValidator : AbstractValidator<LoginUserViewModel> {
        public LoginUserValidator() {

            
            RuleFor(user => user.Phone)
                    .NotEmpty()
                    .NotNull();
            
            RuleFor(user => user.Password)
                    .NotEmpty()
                    .NotNull();
            
        }


    }
}
