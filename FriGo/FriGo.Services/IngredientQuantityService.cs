using FriGo.DAL;
using FriGo.Db.Models.Ingredient;
using FriGo.Interfaces.Dependencies;
using FriGo.ServiceInterfaces;

namespace FriGo.Services
{
    public class IngredientQuantityService : CrudService<IngredientQuantity>, IIngredientQuantityService, IRequestDependency
    {
        public IngredientQuantityService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}