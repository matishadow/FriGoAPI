using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FriGo.Db.Models.Social;
using FriGo.Db.ModelValidators;

namespace FriGo.Db.Models.Ingredients
{
    [Validator(typeof(IngredientQuantityValidator))]
    public class IngredientQuantity : Entity
    {
        public decimal Quantity { get; set; }
        public string Description { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
