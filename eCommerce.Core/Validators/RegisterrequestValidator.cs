using FluentValidation;
using UserService.Core.DTOs;

namespace UserService.Core.Validators
{
    public class RegisterrequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterrequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Person Name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be 6 characters");



        }
    }
}
