using FriGo.Db.Models.Ingredients;
using FriGo.Interfaces.DAL;
using FriGo.Interfaces.Dependencies;
using FriGo.Interfaces.ServiceInterfaces;

namespace FriGo.Core.Services
{
    public class IngredientQuantityService : CrudService<IngredientQuantity>, IIngredientQuantityService, IRequestDependency
    {
        public IngredientQuantityService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}