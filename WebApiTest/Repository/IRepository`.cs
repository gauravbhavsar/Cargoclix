using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Repository {
    public interface IEventManager { }
    public interface IRepository<TEntity, in TKey>:IRepository where TEntity:class {
        TEntity ById(TKey id);
        IQueryable<TEntity> ById(IEnumerable<TKey> ids);
        int Create(TEntity entity); //returns Rows Affected
        int Create(ICollection<TEntity> entity); //returns Rows Affected
        int Update(TEntity entity); //returns Rows Affected
        int Delete(TEntity entity); //returns Rows Affected
        void Attach(TEntity entity); //returns Rows Affected
        int Delete(ICollection<TEntity> entities); //returns Rows Affected
        string OriginalValues(TEntity entity);

        Task<int> CreateAsync(TEntity entity); //returns Rows Affected
        Task<int> CreateAsync(ICollection<TEntity> entities); //returns Rows Affected
        Task<int> UpdateAsync(TEntity entity); //returns Rows Affected
        Task<int> DeleteAsync(TEntity entity); //returns Rows Affected
        Task<int> DeleteAsync(ICollection<TEntity> entities); //returns Rows Affected

        IQueryable<TEntity> All { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
