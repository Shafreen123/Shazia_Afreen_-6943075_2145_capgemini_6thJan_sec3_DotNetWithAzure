using ECommerceApp.Core.DTOs.Auth;
using FluentValidation;

namespace ECommerceApp.Core.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("Password must have at least one uppercase letter.")
                .Matches("[0-9]").WithMessage("Password must have at least one number.");
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\+?[0-9]{10,15}$");
        }
    }
}