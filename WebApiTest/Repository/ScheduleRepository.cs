using System.Collections.Generic;
using System.Linq;
using WebApiTest.Models;

namespace WebApiTest.Repository {
    public interface IScheduleRepository:IRepository<Schedule, int> {

    }
    public class ScheduleRepository:EfRepository<Schedule, int>, IScheduleRepository {
        public ScheduleRepository(IApplicationDataContext context)
            : base(context) {}

        public override IQueryable<Schedule> ById(IEnumerable<int> ids) {
            return All.Where(x => ids.Contains(x.Id));
        }
    }
}