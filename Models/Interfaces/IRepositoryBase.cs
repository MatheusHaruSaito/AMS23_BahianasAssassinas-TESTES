using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS23_Carousel.Models.Interfaces
{
    public interface IRepositoryBase<TEntity, Tkey> where TEntity : class 
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
      /*  IEnumerable<TEntity> GetAll(); ele funciona em base de memoria (ele filtra na tela do cliente)
        IQueryable<TEntity> GetAll(); uma lista que trabalha na base de dados (antes de ir para a tela do cliente ele é filtrado no banco de dados)
        ICollection<TEntity> GetAll();  */
        Task<TEntity> GetById(Guid Id);
             Task<IEnumerable<TEntity>> GetAll();
        Task<bool> SaveChangesAsync();

    }

 
}