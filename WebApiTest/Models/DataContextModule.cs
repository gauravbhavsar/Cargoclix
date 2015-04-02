using System.Data.Entity;
using Autofac;

namespace WebApiTest.Models {
    public class DataContextModule:Module {
        protected override void Load(ContainerBuilder builder) {

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDataContext>().As<DbContext>().As<ApplicationDbContext>();

            Database.SetInitializer(new NullDatabaseInitializer<ApplicationDbContext>());
        }
    }
}