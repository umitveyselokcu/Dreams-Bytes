using DreamsBytes.Core;
using DreamsBytes.Data.Repositories;
using DreamsBytes.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using DreamsBytes.Core.Entites;
using System.Linq;

namespace DreamsBytes.Data.UnitOfWork
{
    public class UnitOfWork : EFDataContext, IUnitOfWork 
    {
        private bool disposed = false;
        private readonly EFDataContext _context;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        
        public UnitOfWork()
        {
            _context = new EFDataContext();
        
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            IRepository<TEntity> repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            _context
                .ChangeTracker
                .Entries()
                .ToList()
                .ForEach(x => x.Reload());
        }
    }
}