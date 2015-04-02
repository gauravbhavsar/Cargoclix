using Autofac;

namespace WebApiTest.Repository {
    public class DataAccessLayerModule:Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<ScheduleRepository>().As<IScheduleRepository>();
            builder.RegisterType<DeliveryRepository>().As<IDeliveryRepository>();
            builder.RegisterType<NotesRepository>().As<IDeliveryRepository>();
            builder.RegisterType<ETARepository>().As<IETARepository>();
            builder.RegisterType<DriverRepository>().As<IDriverRepository>();
            builder.RegisterType<OwnerRepository>().As<IOwnerRepository>();
        }
    }
}
