using FriGo.Db.Models.Ingredients;
using FriGo.Interfaces.DAL;
using FriGo.Interfaces.Dependencies;
using FriGo.Interfaces.ServiceInterfaces;

namespace FriGo.Core.Services
{
    public class IngredientService : CrudService<Ingredient>, IIngredientService, IRequestDependency
    {
        public IngredientService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}