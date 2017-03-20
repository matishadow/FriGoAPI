using FriGo.Db.Models.Recipe;

namespace FriGo.Db.DTO.Recipe
{
    public class CreateRecipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Models.Ingredient.Ingredient[] Ingredients { get; set; }
        public Tag[] Tags { get; set; }        
        public string Base64Picture { get; set; }
    }
}