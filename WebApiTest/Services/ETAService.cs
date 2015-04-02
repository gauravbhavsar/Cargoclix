using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.Extensions;
using WebApiTest.ViewModels;
using WebApiTest.Repository;

namespace WebApiTest.Services {
    public interface IETAService:IDataService<ETA, int, ETAUpdateCommand, ETACreateCommand, ETADeleteCommand> {
        ETAViewModel ById(int id);
    }

    public class ETAService:DataServiceBase<ETA, int, ETAUpdateCommand, ETACreateCommand, ETADeleteCommand>, IETAService {

        private readonly IETARepository _repository;

        public ETAService(IETARepository repository) {
            _repository = repository;
        }
        protected override IRepository<ETA, int> Repository {
            get { return _repository; }
        }

        public override ETA CommandToEntity(ETACreateCommand command) {
            return command.ToEntity();
        }

        public override ETA CommandToEntity(ETAUpdateCommand command, ETA entity) {
            return command.ToEntity(entity);
        }

        public ETAViewModel ById(int id) {
            return _repository.ById(id).ToETAViewModels();
        }
    }
}