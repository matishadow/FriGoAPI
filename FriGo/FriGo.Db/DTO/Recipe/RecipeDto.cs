using System;
using System.Collections.Generic;
using FriGo.Db.DTO.Account;
using FriGo.Db.DTO.Social;
using FriGo.Db.Models.Recipe;
using FriGo.Db.Models.Social;

namespace FriGo.Db.DTO.Recipe
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Models.Ingredient.IngredientQuantity[] IngredientQuantities { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public IEnumerable<Tag> Tags { get; set;}
        public UserStub User { get; set; }
        public string Base64Picture { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Fitness { get; set; }
        public IEnumerable<Models.Ingredient.IngredientQuantity> MissingIngredientQuantities { get; set; }
    }
}