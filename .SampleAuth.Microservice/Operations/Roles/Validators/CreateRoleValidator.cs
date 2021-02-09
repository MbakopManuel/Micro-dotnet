using FluentValidation;
using SampleAuth.Microservice.Operations.Role.ViewModels;

namespace SampleAuth.Microservice.Operations.Role.Validator{
    public class CreateRoleValidator : AbstractValidator<CreateRoleViewModel> {
        public CreateRoleValidator() {

            RuleFor(role => role.Name)
                    .NotEmpty()
                    .NotNull();
            
            
        }


    }
}
