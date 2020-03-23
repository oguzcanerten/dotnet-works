using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetcoreProject.Core.Service
{
    public interface IService<TEntity> where TEntity : class
    {

        //Aynı metodları tekrar yazmamızın nedeni service'in hep aynı kalacak olması,oracle vb. geçilirse sadece implementasyon değişicek.
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task <TEntity> AddAsync(TEntity entity); //Tentity döndüm
        Task <IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);


    }
}
