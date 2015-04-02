using System.Collections.Generic;
using System.Linq;
using WebApiTest.Models;

namespace WebApiTest.Repository {
    public interface IETARepository:IRepository<ETA, int> {

    }
    public class ETARepository:EfRepository<ETA, int>, IETARepository {
        public ETARepository(IApplicationDataContext context)
            : base(context) { }

        public override IQueryable<ETA> ById(IEnumerable<int> ids) {
            return All.Where(x => ids.Contains(x.Id));
        }
    }
}