using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.Repository;

namespace WebApiTest.Services {
    public abstract class DataServiceBase<TEntity, TKey, TUpdate, TCreate, TDelete>
        :IDataService<TEntity, TKey, TUpdate, TCreate, TDelete>
        where TEntity:class
        where TUpdate:IUpdateCommand<TKey>
        where TDelete:IDeleteCommand<TKey>
        where TCreate:ICreateCommand {
        protected abstract IRepository<TEntity, TKey> Repository { get; }
        public abstract TEntity CommandToEntity(TCreate command);
        public abstract TEntity CommandToEntity(TUpdate command, TEntity entity);

        public virtual bool EnableLog {
            get { return false; }
        }

        public virtual void OnSuccess(ActionEnum act, TEntity entity, string data) {
            //this functions to be used to catch on save completed, and log history.
        }

        public virtual DataExecutionResult<TEntity> Execute(TCreate command) {
            return Create(CommandToEntity(command));
        }
        public virtual DataExecutionResult<TEntity> Execute(TUpdate command) {
            return Update(CommandToEntity(command, Repository.ById(command.Id)));
        }
        public virtual int Execute(TDelete command) {
            return Delete(Repository.ById(command.Id));
        }

        protected string GetModifiedValues(TEntity entity) {
            return EnableLog ? Repository.OriginalValues(entity) : "";
        }

        protected virtual DataExecutionResult<TEntity> Update(TEntity entity) {
            var originalValues = GetModifiedValues(entity);
            var rowsAffetced = Repository.Update(entity);
            if(rowsAffetced > 0 && EnableLog) {
                OnSuccess(ActionEnum.Modified, entity, originalValues);
            }
            return new DataExecutionResult<TEntity>() { Entity = entity, RowsAffected = rowsAffetced };
        }

        protected virtual DataExecutionResult<TEntity> Create(TEntity entity) {
            var modifiedValues = GetModifiedValues(entity);
            var rowsAffetced = Repository.Create(entity);
            if(rowsAffetced > 0 && EnableLog) {
                OnSuccess(ActionEnum.Added, entity, modifiedValues);
            }
            return new DataExecutionResult<TEntity>() { Entity = entity, RowsAffected = rowsAffetced };
        }

        protected virtual int Delete(TEntity entity) {
            var modifiedValues = GetModifiedValues(entity);
            var rowAffected= Repository.Delete(entity);
            if(rowAffected > 0 && EnableLog) {
                OnSuccess(ActionEnum.Deleted, entity, modifiedValues);
            }
            return rowAffected;
        }


        protected virtual async Task<DataExecutionResult<TEntity>> UpdateAsync(TEntity entity) {
            var modifiedValues = GetModifiedValues(entity);
            var rowsAffetced = await Repository.UpdateAsync(entity);
            if(rowsAffetced > 0 && EnableLog) {
                OnSuccess(ActionEnum.Modified, entity, modifiedValues);
            }
            return new DataExecutionResult<TEntity>() { Entity = entity, RowsAffected = rowsAffetced };
        }

        protected virtual async Task<DataExecutionResult<TEntity>> CreateAsync(TEntity entity) {
            var modifiedValues = GetModifiedValues(entity);
            var rowsAffetced = await Repository.CreateAsync(entity);
            if(rowsAffetced > 0 && EnableLog) {
                OnSuccess(ActionEnum.Added, entity, modifiedValues);
            }
            return new DataExecutionResult<TEntity>() { Entity = entity, RowsAffected = rowsAffetced };
        }

        protected virtual async Task<int> DeleteAsync(TEntity entity) {
            var modifiedValues = GetModifiedValues(entity);
            var rowAffected = await Repository.DeleteAsync(entity);
            if(rowAffected > 0 && EnableLog) {
                OnSuccess(ActionEnum.Deleted, entity, modifiedValues);
            }
            return rowAffected;
        }

        public virtual IQueryable<TEntity> All {
            get { return Repository.All; }
        }

        public virtual TEntity ByIdEntity(TKey id) {
            return Repository.ById(id);
        }

        public virtual Task<DataExecutionResult<TEntity>> ExecuteAsync(TCreate command) {
            return CreateAsync(CommandToEntity(command));
        }

        public virtual Task<DataExecutionResult<TEntity>> ExecuteAsync(TUpdate command) {
            return UpdateAsync(CommandToEntity(command, Repository.ById(command.Id)));
        }

        public virtual Task<int> ExecuteAsync(TDelete command) {
            return DeleteAsync(Repository.ById(command.Id));
        }
    }

}