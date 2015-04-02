using Autofac;
using WebApiTest.Services;

namespace WebApiTest.Services {
    public class ServicesModule:Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<ScheduleService>().As<IScheduleService>();
            builder.RegisterType<DeliveryService>().As<IDeliveryService>();
            builder.RegisterType<NotesService>().As<INotesService>();
            builder.RegisterType<ETAService>().As<IETAService>();
        }
    }
}
