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
    public interface INotesService:IDataService<Notes, int, NotesUpdateCommand, NotesCreateCommand, NotesDeleteCommand> {
        NotesViewModel ById(int id);
    }

    public class NotesService:DataServiceBase<Notes, int, NotesUpdateCommand, NotesCreateCommand, NotesDeleteCommand>, INotesService {

        private readonly INotesRepository _repository;

        public NotesService(INotesRepository repository) {
            _repository = repository;
        }
        protected override IRepository<Notes, int> Repository {
            get { return _repository; }
        }

        public override Notes CommandToEntity(NotesCreateCommand command) {
            return command.ToEntity();
        }

        public override Notes CommandToEntity(NotesUpdateCommand command, Notes entity) {
            return command.ToEntity(entity);
        }

        public NotesViewModel ById(int id) {
            return _repository.ById(id).ToNotesViewModels();
        }
    }
}