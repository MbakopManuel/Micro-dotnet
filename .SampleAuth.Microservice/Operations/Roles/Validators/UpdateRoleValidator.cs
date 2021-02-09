using FluentValidation;
using SampleAuth.Microservice.Operations.Role.ViewModels;

namespace SampleAuth.Microservice.Operations.Role.Validator{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleViewModel> {
        public UpdateRoleValidator() {

                RuleFor(role => role.Id)
                    .NotEmpty()
                    .NotNull();
                RuleFor(role => role.Name)
                    .NotEmpty()
                    .NotNull();
            
            
        }


    }
}
