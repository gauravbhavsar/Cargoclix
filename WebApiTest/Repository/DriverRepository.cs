using System.Collections.Generic;
using System.Linq;
using WebApiTest.Models;

namespace WebApiTest.Repository {
    public interface IDriverRepository:IRepository<Driver, int> {

    }

    public class DriverRepository:EfRepository<Driver, int>, IDriverRepository {

        public DriverRepository(IApplicationDataContext context)
            : base(context) { }

        public override IQueryable<Driver> ById(IEnumerable<int> ids) {
            return All.Where(x => ids.Contains(int.Parse(x.Id)));
        }
    }
}