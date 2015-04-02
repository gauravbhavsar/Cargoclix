using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.Extensions;
using WebApiTest.ViewModels;
using WebApiTest.Repository;

namespace WebApiTest.Services {
    public interface IDriverService:IDataService<Driver, int, DriverUpdateCommand, DriverCreateCommand, DriverDeleteCommand> {
        DriverViewModel ById(int id);
    }

    public class DriverService:DataServiceBase<Driver, int, DriverUpdateCommand, DriverCreateCommand, DriverDeleteCommand>, IDriverService {
        private readonly IDriverRepository _repository;

        public DriverService(IDriverRepository repository) {
            _repository = repository;
        }

        protected override IRepository<Driver, int> Repository {
            get { return _repository; }
        }

        public override Driver CommandToEntity(DriverCreateCommand command) {
            return command.ToEntity();
        }

        public override Driver CommandToEntity(DriverUpdateCommand command, Driver entity) {
            return command.ToEntity(entity);
        }

        public DriverViewModel ById(int id) {
            return _repository.ById(id).ToDriverViewModels();
        }
    }
}