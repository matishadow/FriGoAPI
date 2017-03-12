using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FriGo.Db.ModelValidators;

namespace FriGo.Db.Models.Ingredients
{
    [Validator(typeof(IngredientQuantityValidator))]
    public class IngredientQuantity : Entity
    {
        public int Quantity { get; set; }
        public Guid IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
