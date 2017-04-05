﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FriGo.Db.DTO.Recipes;
using FriGo.Db.Models;
using FriGo.Db.DTO;
using FriGo.Db.Models.Recipes;
using FriGo.ServiceInterfaces;
using Swashbuckle.Swagger.Annotations;
using System.Linq;
using FriGo.Db.Models.Ingredients;

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
            Recipe recipeResult = recipeService.Get(id);
            if (recipeResult != null)
            {
                RecipeDto returnRecipe = AutoMapper.Map<Recipe, RecipeDto>(recipeResult);
                return Request.CreateResponse(HttpStatusCode.OK, returnRecipe);
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Recipe {id} do not exist");
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
        public virtual HttpResponseMessage Get(Tag[] tagQuery, int page = 1, int perPage = 10, string sortField = null,
            bool descending = false, string nameSearchQuery = null)
        {
            if (IsEmpty(tagQuery))
                tagQuery = TakeAllTags().ToArray();

            IEnumerable<Recipe> recipeResults = recipeService.Get()
                                                    .FilterByName(nameSearchQuery)
                                                    .FilterByTag(tagQuery)
                                                    .SortByField(sortField, descending)
                                                    .Skip((page - 1) * perPage).Take(perPage);

            if (recipeResults.Count() > 0)
            {
                IEnumerable<RecipeDto> returnRecipes = AutoMapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeDto>>(recipeResults);
                return Request.CreateResponse(HttpStatusCode.OK, returnRecipes);
            }
            else
                return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        private bool IsEmpty(Tag[] tagQuery)
        {
            return tagQuery.Count() > 0;
        }
        private ICollection<Tag> TakeAllTags()
        {
            throw new NotImplementedException();
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
            if (nameSearchQuery != null)
                return recipes.Where(x => x.Title.Contains(nameSearchQuery));
            else
                return recipes;
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
                return recipes.OrderBy (x => x.Rating);
            }
            catch (ArgumentNullException)
            {
            }
            catch (ArgumentException)
            {
                var checkProperty = typeof(Recipe).GetProperty(field,
                      System.Reflection.BindingFlags.Instance |
                      System.Reflection.BindingFlags.Public |
                      System.Reflection.BindingFlags.NonPublic).PropertyType;


                if (checkProperty == typeof(ICollection<Tag>))
                    return SortByTags(recipes);
                else if (checkProperty == typeof(ICollection<IngredientQuantity>))
                    return SortByIngredients(recipes);              
            }
            catch (NullReferenceException)
            {
            }
            return recipes ?? new List<Recipe>();
        }

        private static IEnumerable<Recipe> SortByIngredients(IEnumerable<Recipe> recipes)
        {
            //add filters for ingredients in fridge
            //metoda do która wylicza wskaźnik produktów
            throw new NotImplementedException();
        }

        private static IEnumerable<Recipe> SortByTags(IEnumerable<Recipe> recipes)
        {
            throw new NotImplementedException();
        }
    }
}
