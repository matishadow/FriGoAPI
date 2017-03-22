using System;
using System.Collections.Generic;
using FriGo.Db.DTO.Recipes;
using FriGo.Db.Models.Ingredients;
using FriGo.Db.Models.Social;

namespace FriGo.Db.DTO.Social
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<CommentStub> Comments { get; set; }
        public IEnumerable<RecipeStub> Recipes { get; set; }
        public IEnumerable<IngredientQuantity> IngredientQuantities { get; set; }
    }
}