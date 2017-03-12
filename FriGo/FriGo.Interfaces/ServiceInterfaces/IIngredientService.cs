using System;
using System.Collections.Generic;
using FriGo.Db.Models.Ingredients;

namespace FriGo.Interfaces.ServiceInterfaces
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> Get();
        Ingredient Get(Guid id);
        void Add(Ingredient ingredient);
        void Edit(Ingredient ingredient);
        void Delete(Guid id);
    }
}