using System.Collections.Generic;
using System.Linq;
using WebApiTest.Models;

namespace WebApiTest.Repository {
    public interface IOwnerRepository:IRepository<Owner, int> {

    }

    public class OwnerRepository:EfRepository<Owner, int>, IOwnerRepository {

        public OwnerRepository(IApplicationDataContext context)
            : base(context) { }

        public override IQueryable<Owner> ById(IEnumerable<int> ids) {
            return All.Where(x => ids.Contains(int.Parse(x.Id)));
        }
    }
}