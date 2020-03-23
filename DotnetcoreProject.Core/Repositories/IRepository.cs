using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetcoreProject.Core.Repositories
{
    public interface IRepository <TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task <IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate); 
        // tentity alan geriye bool dönen bi metodu işaret eder (delegate)
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        //(x => x.name = "kalem" yukarıdaki şeye denk geliyor(Expression))

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);



    }
}
