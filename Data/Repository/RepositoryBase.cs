using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS23_Carousel.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AMS23_Carousel.Data.Repository
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class

    {
        private readonly ApplicationDataContext _applicatioDataContext;
        protected readonly DbSet<TEntity> _entity;
        public RepositoryBase(ApplicationDataContext applicationDataContext)
        {
            _applicatioDataContext = applicationDataContext;
            _entity = _applicatioDataContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _entity.Add(entity);
            
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _entity.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _applicatioDataContext.SaveChangesAsync() > 0;
        }
    }
}