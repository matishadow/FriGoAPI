using FluentValidation;
using FriGo.Db.Models.Ingredients;

namespace FriGo.Db.ModelValidators
{
    public class IngredientValidator : AbstractValidator<Ingredient>
    {
        public IngredientValidator()
        {
            RuleFor(ingredient => ingredient.Name)
                .NotEmpty()
                .Length(1, 100)
                .WithMessage(Properties.Resources.IngredientNameValidationMessage);
        }
    }
}