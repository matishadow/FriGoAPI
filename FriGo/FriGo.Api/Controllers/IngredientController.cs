using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FriGo.Api.DAL;
using FriGo.Db.Models.Ingredients;
using FriGo.Interfaces.ServiceInterfaces;

namespace FriGo.Api.Controllers
{
    public class IngredientController : ApiController
    {
        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        public virtual IEnumerable<Ingredient> Get()
        {
            return ingredientService.Get();
        }

        public virtual Ingredient Get(Guid id)
        {
            return ingredientService.Get(id);
        }

        public virtual void Post(Ingredient ingredient)
        {
            ingredientService.Add(ingredient);
        }

        public virtual void Put(Ingredient ingredient)
        {
            ingredientService.Edit(ingredient);
        }

        public virtual void Delete(Guid id)
        {
            ingredientService.Delete(id);
        }
    }
}
