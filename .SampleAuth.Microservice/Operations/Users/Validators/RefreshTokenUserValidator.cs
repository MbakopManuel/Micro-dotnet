using FluentValidation;
using SampleAuth.Microservice.Operations.User.ViewModels;

namespace SampleAuth.Microservice.Operations.User.Validator{
    public class RefreshTokenUserValidator : AbstractValidator<RefreshTokenUserViewModel> {
        public RefreshTokenUserValidator() {

            RuleFor(user => user.RefreshToken)
                    .NotEmpty()
                    .NotNull();
            
        }


    }
}
