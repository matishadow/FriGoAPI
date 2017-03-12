using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FriGo.Db.Models.Ingredients;
using FriGo.Interfaces.ServiceInterfaces;

namespace FriGo.Api.Controllers
{
    public class IngredientQuantityController : ApiController
    {
        private readonly IIngredientQuantityService ingredientQuantityService;

        public IngredientQuantityController(IIngredientQuantityService ingredientQuantityService)
        {
            this.ingredientQuantityService = ingredientQuantityService;
        }

        public IEnumerable<IngredientQuantity> Get()
        {
            return ingredientQuantityService.Get();
        }

        public IngredientQuantity Get(Guid id)
        {
            return ingredientQuantityService.Get(id);
        }

        public void Post(IngredientQuantity ingredientQuantity)
        {
            ingredientQuantityService.Add(ingredientQuantity);
        }

        public void Put(IngredientQuantity ingredientQuantity)
        {
            ingredientQuantityService.Edit(ingredientQuantity);
        }

        public void Delete(Guid id)
        {
            ingredientQuantityService.Delete(id);
        }
    }
}
