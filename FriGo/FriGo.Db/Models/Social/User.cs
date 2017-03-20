using System.Collections.Generic;
using FriGo.Db.Models.Authentication;
using FriGo.Db.Models.Ingredients;
using FriGo.Db.Models.Recipes;

namespace FriGo.Db.Models.Social
{
    public class User : ApplicationUser
    {
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<IngredientQuantity> IngredientQuantities { get; set; }
    }
}
