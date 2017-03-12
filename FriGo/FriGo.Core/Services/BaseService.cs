using FriGo.Interfaces.DAL;

namespace FriGo.Core.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}