using FluentValidation;
using FriGo.Db.Models.Authentication;
using FriGo.Db.Models.Ingredients;

namespace FriGo.Db.ModelValidators
{
    public class RegisterValidator : AbstractValidator<RegisterBindingModel>
    {
        public RegisterValidator()
        {
            RuleFor(register => register.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(register => register.Username)
                .NotEmpty();

            const int minimalPasswordLength = 10;

            RuleFor(register => register.Password)
                .Length(minimalPasswordLength, 100)
                .WithMessage(string.Format(Properties.Resources.PasswordLengthValidationMessage, minimalPasswordLength))
                .NotEmpty();

            RuleFor(register => register.ConfirmPassword)
                .Equal(register => register.Password)
                .NotEmpty();
        }
    }
}