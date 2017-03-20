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
using FriGo.ServiceInterfaces;
using Swashbuckle.Swagger.Annotations;

namespace FriGo.Api.Controllers
{
    public class RateController : ApiController
    {
        /// <summary>
        /// Get rating of recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns>Rating of a recipe</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(decimal), Description = "Rate")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not found")]
        public virtual HttpResponseMessage Get(Guid recipeId)
        {
            throw new NotImplementedException();
        }        

        /// <summary>
        /// Rate recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="rateRecipe"></param>
        /// <returns></returns>
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(decimal), Description = "Rate")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(Error), Description = "Not found")]
        [Authorize]
        public virtual HttpResponseMessage Put(Guid recipeId, RateRecipe rateRecipe)
        {
            throw new NotImplementedException();
        }
    }
}
