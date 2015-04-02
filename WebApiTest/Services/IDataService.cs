using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApiTest.Commands;

namespace WebApiTest.Services {
    public interface IDataService<out TEntity>:IService
        where TEntity:class {
        IQueryable<TEntity> All { get; }
    }

    public interface IHandler { }

    public interface ICreateHandler<TEntity, in TCommand>:IHandler where TCommand:ICreateCommand {
        DataExecutionResult<TEntity> Execute(TCommand cmd);
        Task<DataExecutionResult<TEntity>> ExecuteAsync(TCommand cmd);
        TEntity CommandToEntity(TCommand cmd);
    }

    public interface ICreateHandler<in TCommand>:IHandler where TCommand:ICreateCommand {
        Task<int> ExecuteAsync(TCommand cmd); //rows affected
        int Execute(TCommand cmd); //rows affected
    }

    public interface IUpdateHandler<TEntity, TKey, in TCommand>:IHandler where TCommand:IUpdateCommand<TKey> {
        DataExecutionResult<TEntity> Execute(TCommand cmd);
        Task<DataExecutionResult<TEntity>> ExecuteAsync(TCommand cmd);
        TEntity CommandToEntity(TCommand cmd, TEntity entity);
    }

    public interface IDeleteHandler<TKey, in TCommand>:IHandler where TCommand:IDeleteCommand<TKey> {
        int Execute(TCommand cmd); //rows affected;
        Task<int> ExecuteAsync(TCommand cmd); //rows affected;
    }

    public interface IDataService<TEntity, TKey, in TUpdate, in TCreate, in TDelete>:IDataService<TEntity>,
        ICreateHandler<TEntity, TCreate>,
        IDeleteHandler<TKey, TDelete>,
        IUpdateHandler<TEntity, TKey, TUpdate>
        where TEntity:class
        where TUpdate:IUpdateCommand<TKey>
        where TDelete:IDeleteCommand<TKey>
        where TCreate:ICreateCommand {
        TEntity ByIdEntity(TKey id);
    }

    public class DataExecutionResult<T> {
        public int RowsAffected { get; set; }
        public T Entity { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}