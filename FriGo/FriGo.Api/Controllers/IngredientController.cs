using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FriGo.Db.DTO.Ingredient;
using FriGo.Db.Models;
using FriGo.Db.Models.Ingredient;
using FriGo.ServiceInterfaces;
using Swashbuckle.Swagger.Annotations;

namespace FriGo.Api.Controllers
{
    public class IngredientController : ApiController
    {
        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        /// <summary>
        /// Returns all ingredients
        /// </summary>
        /// <returns>An array of ingredients</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<Ingredient>))]
        public virtual HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ingredientService.Get());
        }

        /// <summary>
        /// Get one ingredient by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One ingredient</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Ingredient))]
        public virtual HttpResponseMessage Get(Guid id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ingredientService.Get(id));
        }

        /// <summary>
        /// Create new ingredient
        /// </summary>
        /// <param name="createIngredient"></param>
        /// <returns>Created ingredient</returns>
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(Ingredient), Description = "Ingredient created")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [Authorize]
        public virtual HttpResponseMessage Post(CreateIngredient createIngredient)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modify existing ingredient
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editIngredient"></param>
        /// <returns>Modified ingredient</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Ingredient), Description = "Ingredient updated")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(Error), Description = "Not found")]
        [Authorize]
        public virtual HttpResponseMessage Put(Guid id, EditIngredient editIngredient)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete ingredient
        /// </summary>
        /// <param name="id"></param>
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Ingredient deleted")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(Error), Description = "Not found")]
        [Authorize]
        public virtual HttpResponseMessage Delete(Guid id)
        {
            ingredientService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
