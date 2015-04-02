using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Repository {
    public abstract class EfRepository<TEntity, TKey>:IRepository<TEntity, TKey> where TEntity:class {
        protected EfRepository(IApplicationDataContext context, IEventManager eventManager) {
            Context = context;
        }

        protected EfRepository(IApplicationDataContext context) : this(context, new DefaultDataEventManager()) { }

        protected IApplicationDataContext Context { get; private set; }

        public abstract IQueryable<TEntity> ById(IEnumerable<TKey> ids);

        public virtual IQueryable<TEntity> All {
            get { return Context.Set<TEntity>(); }
        }

        public virtual int Create(TEntity entity) {
            Context.Entry(entity).State = EntityState.Added;
            var rowsAfftected = Context.SaveChanges();
            return rowsAfftected;
        }

        public virtual Task<int> CreateAsync(TEntity entity) {
            Context.Entry(entity).State = EntityState.Added;
            return Context.SaveChangesAsync();
        }

        public virtual TEntity ById(TKey id) {
            var entity = Context.Set<TEntity>().Find(id);
            return entity;
        }

        public virtual int Delete(TEntity entity) {
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
            var rowsAffected=Context.SaveChanges();
            return rowsAffected;
        }

        public virtual Task<int> DeleteAsync(TEntity entity) {
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public virtual int Update(TEntity entity) {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            var rowsAffected = Context.SaveChanges();
            return rowsAffected;
        }

        public virtual Task<int> UpdateAsync(TEntity entity) {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        protected void AttachDetachedCollection<T>(ICollection<T> entities) where T:class {
            foreach(T entity in entities) {
                Context.Set<T>().Attach(entity);
                Context.Entry(entity).State = EntityState.Unchanged;
            }
        }

        public void Attach(TEntity entity) {
            Context.Set<TEntity>().Attach(entity);
        }
        internal void Attach(ICollection<TEntity> entities) {
            throw new NotImplementedException();
        }

        internal delegate void EntityEvent(TEntity entity);

        public IEventManager EventManager { get; private set; }

        public virtual int Create(ICollection<TEntity> entities) {
            Attach(entities);
            return Context.SaveChanges();
        }

        public virtual int Delete(ICollection<TEntity> entities) {
            throw new NotImplementedException();
        }

        public virtual async Task<int> CreateAsync(ICollection<TEntity> entities) {
            Attach(entities);
            return await Context.SaveChangesAsync();
        }

        public virtual Task<int> DeleteAsync(ICollection<TEntity> entities) {
            throw new NotImplementedException();
        }

        public int SaveChanges() {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync() {
            return await Context.SaveChangesAsync();
        }

        public string OriginalValues(TEntity entity) {
            var entry = Context.Entry(entity);
            if(entry == null || entry.State== EntityState.Detached) {
                return entity.ToString();
            }
            return entry.OriginalValues.PropertyNames.Where(p => entry.CurrentValues[p]!=null && !entry.CurrentValues[p].Equals(entry.OriginalValues[p])).ToDictionary(p => p, p => entry.CurrentValues[p]).ToString();
        }
    }
}