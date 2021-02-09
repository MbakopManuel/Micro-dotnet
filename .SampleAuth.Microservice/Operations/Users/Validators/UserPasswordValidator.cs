using FluentValidation;
using SampleAuth.Microservice.Operations.User.ViewModels;

namespace SampleAuth.Microservice.Operations.User.Validator{
    public class UserPasswordValidator : AbstractValidator<UserPasswordViewModel> {
        public UserPasswordValidator() {

            
            RuleFor(User => User.odlpassword)
                    .NotEmpty()
                    .NotNull();
            
            RuleFor(User => User.newpassword)
                    .NotEmpty()
                    .NotNull();
            
        }


    }
}
