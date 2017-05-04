using FluentValidation;
using FriGo.Db.Models.Authentication;

namespace FriGo.Db.ModelValidators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordBindingModel>
    {
        public ChangePasswordValidator()
        {
            const int minimalPasswordLength = 10;

            RuleFor(changePassword => changePassword.OldPassword)
                .NotEmpty();

            RuleFor(changePassword => changePassword.NewPassword)
                .Length(minimalPasswordLength, 100)
                .WithMessage(string.Format(Properties.Resources.PasswordLengthValidationMessage, minimalPasswordLength))
                .NotEmpty();

            RuleFor(changePassword => changePassword.ConfirmPassword)
                .Matches(changePassword => changePassword.NewPassword)
                .WithMessage(Properties.Resources.ConfirmPasswordValidationMessage);
        }
    }
}