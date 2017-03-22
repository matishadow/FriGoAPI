using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FriGo.Db.Models.Ingredients;

namespace FriGo.Db
{
    public class FrigoDbInitializer : DropCreateDatabaseIfModelChanges<FrigoContext>
    {
        private IEnumerable<Ingredient> CreateIngredients()
        {
            string[] ingredientList = Properties.Resources.IngredientList
                .Split(new[] { Environment.NewLine}, StringSplitOptions.None);

            List<Ingredient> ingredients =
                ingredientList.Select(ingredientName => new Ingredient {Id = Guid.NewGuid(), Name = ingredientName})
                    .ToList();

            return ingredients;
        }

        protected override void Seed(FrigoContext context)
        {
            context.Set<Ingredient>().AddRange(CreateIngredients());

            base.Seed(context);
        }
    }
}