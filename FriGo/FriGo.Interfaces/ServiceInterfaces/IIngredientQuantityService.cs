using System;
using System.Collections.Generic;
using FriGo.Db.Models.Ingredients;

namespace FriGo.Interfaces.ServiceInterfaces
{
    public interface IIngredientQuantityService
    {
        IEnumerable<IngredientQuantity> Get();
        IngredientQuantity Get(Guid id);
        void Add(IngredientQuantity ingredient);
        void Edit(IngredientQuantity ingredient);
        void Delete(Guid id);
    }
}