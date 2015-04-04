using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.Extensions;
using WebApiTest.ViewModels;
using WebApiTest.Repository;

namespace WebApiTest.Services
{
    public interface IScheduleService:IDataService<Schedule, int, ScheduleUpdateCommand, ScheduleCreateCommand, ScheduleDeleteCommand> {
        ScheduleViewModel ById(int id);
    }

    public class ScheduleService:DataServiceBase<Schedule, int, ScheduleUpdateCommand, ScheduleCreateCommand, ScheduleDeleteCommand>, IScheduleService
    {
        private readonly IScheduleRepository _repository;

        public ScheduleService(IScheduleRepository repository){
            _repository = repository;
        }

        protected override IRepository<Schedule, int> Repository {
            get { return _repository; }
        }

        public override Schedule CommandToEntity(ScheduleCreateCommand command) {
            return command.ToEntity();
        }

        public override Schedule CommandToEntity(ScheduleUpdateCommand command, Schedule entity) {
            return command.ToEntity(entity);
        }

        public ScheduleViewModel ById(int id) {
            return _repository.ById(id).ToScheduleViewModels();
        }
    }
}