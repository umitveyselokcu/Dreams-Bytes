using DreamsBytes.Core;
using DreamsBytes.Core.Entites;
using DreamsBytes.Data.Repositories;
using System;

namespace DreamsBytes.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        public int Complete();



    }
}