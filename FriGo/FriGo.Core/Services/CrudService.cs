using System;
using System.Collections.Generic;
using FriGo.Interfaces.DAL;
using FriGo.Interfaces.Dependencies;

namespace FriGo.Core.Services
{
    public abstract class CrudService<TEntity> : BaseService, IRequestDependency where TEntity : class 
    {
        protected CrudService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<TEntity> Get()
        {
            return UnitOfWork.Repository<TEntity>().GetAll();
        }

        public TEntity Get(Guid id)
        {
            return UnitOfWork.Repository<TEntity>().GetById(id);
        }

        public void Add(TEntity ingredient)
        {
            UnitOfWork.Repository<TEntity>().Insert(ingredient);

            UnitOfWork.Save();
        }

        public void Edit(TEntity ingredient)
        {
            UnitOfWork.Repository<TEntity>().Edit(ingredient);

            UnitOfWork.Save();
        }

        public void Delete(Guid id)
        {
            UnitOfWork.Repository<TEntity>().Delete(id);

            UnitOfWork.Save();
        }
    }
}