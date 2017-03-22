using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FriGo.Db.Models.Ingredients;

namespace FriGo.Db
{
    public class FrigoDbInitializer : DropCreateDatabaseIfModelChanges<FrigoContext>
    {
        private string[] SplitList(string list)
        {
            return list.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        private IEnumerable<Ingredient> CreateIngredients(IEnumerable<Unit> units)
        {
            string[] ingredientList = SplitList(Properties.Resources.IngredientList);

            List<Ingredient> ingredients =
                ingredientList.Select(
                        ingredientName =>
                            new Ingredient
                            {
                                Id = Guid.NewGuid(),
                                Name = ingredientName,
                                UnitId = units.FirstOrDefault().Id
                            })
                    .ToList();

            return ingredients;
        }

        private IEnumerable<Unit> CreateUnits()
        {
            string[] unitList = SplitList(Properties.Resources.UnitList); 

            List<Unit> units = unitList.Select(unitName => new Unit {Id = Guid.NewGuid(), Name = unitName}).ToList();

            return units;
        }

        protected override void Seed(FrigoContext context)
        {
            List<Unit> units = CreateUnits().ToList();
            context.Set<Unit>().AddRange(units);

            context.Set<Ingredient>().AddRange(CreateIngredients(units));

            base.Seed(context);
        }
    }
}