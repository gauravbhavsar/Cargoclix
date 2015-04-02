using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.Extensions;
using WebApiTest.ViewModels;
using WebApiTest.Repository;

namespace WebApiTest.Services {
    public interface IOwnerService:IDataService<Owner, int, OwnerUpdateCommand, OwnerCreateCommand, OwnerDeleteCommand> {
        OwnerViewModel ById(int id);
    }

    public class OwnerService:DataServiceBase<Owner, int, OwnerUpdateCommand, OwnerCreateCommand, OwnerDeleteCommand>, IOwnerService {
        private readonly IOwnerRepository _repository;

        public OwnerService(IOwnerRepository repository) {
            _repository = repository;
        }

        protected override IRepository<Owner, int> Repository {
            get { return _repository; }
        }

        public override Owner CommandToEntity(OwnerCreateCommand command) {
            return command.ToEntity();
        }

        public override Owner CommandToEntity(OwnerUpdateCommand command, Owner entity) {
            return command.ToEntity(entity);
        }

        public OwnerViewModel ById(int id) {
            return _repository.ById(id).ToOwnerViewModels();
        }
    }
}