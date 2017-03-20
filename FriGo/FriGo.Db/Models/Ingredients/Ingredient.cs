using FluentValidation.Attributes;
using FriGo.Db.Models.Social;
using FriGo.Db.ModelValidators;

namespace FriGo.Db.Models.Ingredients
{
    [Validator(typeof(IngredientValidator))]
    public class Ingredient : Entity
    {
        public string Name { get; set; }
        public virtual Unit Unit { get; set; }
    }
}