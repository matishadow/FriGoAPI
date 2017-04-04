using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FriGo.Db.DTO.Recipes;
using FriGo.Db.Models;
using FriGo.Db.Models.Recipes;
using FriGo.ServiceInterfaces;
using Swashbuckle.Swagger.Annotations;
using System.Linq;

namespace FriGo.Api.Controllers
{
    public class RecipeController : BaseFriGoController
    {
        private readonly IRecipeService recipeService;
        public RecipeController(IMapper autoMapper, IRecipeService recipeService) : base(autoMapper)
        {
            this.recipeService = recipeService;
        }

        /// <summary>
        /// Get one recipe by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One type of unit</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(RecipeDto))]
        public virtual HttpResponseMessage Get(Guid id)
        {
            Recipe recipeResult = recipeService.Get().FirstOrDefault(x => x.Id == id);
            if (recipeResult != null)
                return Request.CreateResponse(HttpStatusCode.OK, recipeResult);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Recipe {id} don not exist");
        }

        /// <summary>
        /// Get recipe by parameters
        /// </summary>
        /// <param name="page">Number of page</param>
        /// <param name="perPage">Count per page</param>
        /// <param name="sortField">Sorting by field</param>
        /// <param name="descending">Sorting order</param>
        /// <param name="nameSearchQuery">Search by name</param>
        /// <param name="tagQuery">Search by tags</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(RecipeDto))]
        public virtual HttpResponseMessage Get(int page = 1, int perPage = 10, string sortField = null,
            bool descending = false, string nameSearchQuery = null, Tag[] tagQuery = null)
        {
            IEnumerable<Recipe> returnValue = recipeService.Get()
                                                    .FilterByName(nameSearchQuery)
                                                    .FilterByTag(tagQuery)
                                                    .SortByField(sortField, descending)
                                                    .Skip((page - 1) * perPage).Take(perPage);

            if (returnValue.Count() > 0)
                return Request.CreateResponse(HttpStatusCode.OK, returnValue);
            else
                return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        
        /// <summary>
        /// Create new recipe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createRecipe"></param>
        /// <returns>Created unit</returns>
        [Authorize]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(RecipeDto), Description = "Recipe created")]
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

    internal static class EngineRecipeSearch
    {
        public static IEnumerable<Recipe> FilterByName(this IEnumerable<Recipe> recipes, string nameSearchQuery)
        {
            try
            {
                return recipes.Where(x => x.Title.Contains(nameSearchQuery));
            }
            catch (ArgumentNullException)
            {
                return recipes;
            }
        }
        public static IEnumerable<Recipe> FilterByTag(this IEnumerable<Recipe> recipes, Tag[] tags)
        {
            try
            {
                return recipes.Where(x => x.Tags.Select(y => y.Name)
                                     .Intersect(tags.Select(z => z.Name))
                                     .Any());
            }
            catch (ArgumentNullException)
            {
                return recipes;
            }   
        }
        public static IEnumerable<Recipe> SortByField(this IEnumerable<Recipe> recipes, string field, bool descending)
        {
            try
            {
                foreach (var Property in typeof(Recipe).GetType().GetProperties())
                {
                    if (field.ToLower() == Property.Name.ToLower())
                    {
                        Func<Recipe, object> key = x => Property.GetValue(x, null);
                        return descending ? recipes.OrderByDescending(key) : recipes.OrderBy(key);
                    }
                }
                return recipes.OrderBy(x => x.Rating);
            }
            catch (ArgumentNullException)
            {
                return new List<Recipe>();
            }
            catch (NullReferenceException)
            {
                return recipes;
            }   
        }
    }
}
