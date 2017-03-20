using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FriGo.Db.DTO.Ingredient;
using FriGo.Db.DTO.Recipe;
using FriGo.Db.DTO.Unit;
using FriGo.Db.Models;
using FriGo.Db.Models.Ingredient;
using FriGo.Db.Models.Recipe;
using FriGo.ServiceInterfaces;
using Swashbuckle.Swagger.Annotations;

namespace FriGo.Api.Controllers
{
    public class RecipeController : ApiController
    {
        /// <summary>
        /// Returns all recipes
        /// </summary>
        /// <returns>An array of units</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<Recipe>))]
        public virtual HttpResponseMessage Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get one recipe by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One type of unit</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Recipe))]
        public virtual HttpResponseMessage Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create new type of unit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createRecipe"></param>
        /// <returns>Created unit</returns>
        [Authorize]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(Ingredient), Description = "Recipe created")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [Authorize]
        public virtual HttpResponseMessage Post(Guid id, CreateRecipe createRecipe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete recipe
        /// </summary>
        /// <param name="id"></param>
        [Authorize]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Recipe deleted")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(Error), Description = "Not found")]
        [Authorize]
        public virtual HttpResponseMessage Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
