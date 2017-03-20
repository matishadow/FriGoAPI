using FriGo.Db.Models.Recipe;

namespace FriGo.Db.DTO.Recipe
{
    public class CreateRecipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Models.Ingredient.IngredientQuantity[] IngredientQuantities { get; set; }
        public Tag[] Tags { get; set; }        
        public string Base64Picture { get; set; }
    }
}