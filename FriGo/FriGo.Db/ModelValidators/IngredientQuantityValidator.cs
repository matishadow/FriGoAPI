using FluentValidation;
using FriGo.Db.Models.Ingredient;

namespace FriGo.Db.ModelValidators
{
    public class IngredientQuantityValidator : AbstractValidator<IngredientQuantity>
    {
        public IngredientQuantityValidator()
        {
            RuleFor(ingredientQuantity => ingredientQuantity.Quantity)
                .GreaterThan(0)
                .WithMessage(Properties.Resources.IngredientQuantityValidationMessage);
        }
    }
}