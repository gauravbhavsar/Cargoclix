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
    public interface IDeliveryService:IDataService<Delivery, int, DeliveryUpdateCommand, DeliveryCreateCommand, DeliveryDeleteCommand> {
        DeliveryViewModel ById(int id);
    }

    public class DeliveryService:DataServiceBase<Delivery, int, DeliveryUpdateCommand, DeliveryCreateCommand, DeliveryDeleteCommand>, IDeliveryService
    {
        private readonly IDeliveryRepository _repository;

        public DeliveryService(IDeliveryRepository repository) {
            _repository = repository;
        }
        protected override IRepository<Delivery, int> Repository {
            get { return _repository; }
        }

        public override Delivery CommandToEntity(DeliveryCreateCommand command) {
            return command.ToEntity();
        }

        public override Delivery CommandToEntity(DeliveryUpdateCommand command, Delivery entity) {
            return command.ToEntity(entity);
        }

        public DeliveryViewModel ById(int id) {
            return _repository.ById(id).ToDeliveryViewModels();
        }
    }
}