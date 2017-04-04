using FriGo.Db.Models;
using FriGo.Db.Models.Recipes;
using FriGo.Interfaces.Dependencies;
using FriGo.DAL;
using FriGo.ServiceInterfaces;

namespace FriGo.Services

{
    public class RecipeService : CrudService<Recipe>, IRecipeService, IRequestDependency
    {
        public RecipeService(IUnitOfWork unitOfWork) : base (unitOfWork)
        {
            
        }

        
    }
}