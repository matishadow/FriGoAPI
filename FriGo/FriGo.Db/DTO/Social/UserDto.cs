using System;
using System.Collections.Generic;
using FriGo.Db.DTO.Recipe;
using FriGo.Db.Models.Social;

namespace FriGo.Db.DTO.Social
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<RecipeStub> Recipes { get; set; }
        public IEnumerable<Models.Ingredient.IngredientQuantity> IngredientQuantities { get; set; }
    }
}