using FluentValidation.Attributes;
using FriGo.Db.ModelValidators;

namespace FriGo.Db.Models.Authentication
{
    [Validator(typeof(RegisterValidator))]
    public class RegisterBindingModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
