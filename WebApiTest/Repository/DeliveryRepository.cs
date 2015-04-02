using System.Collections.Generic;
using System.Linq;
using WebApiTest.Models;

namespace WebApiTest.Repository {
    public interface IDeliveryRepository:IRepository<Delivery, int> {

    }
    public class DeliveryRepository:EfRepository<Delivery, int>, IDeliveryRepository {
        public DeliveryRepository(IApplicationDataContext context)
            : base(context) { }

        public override IQueryable<Delivery> ById(IEnumerable<int> ids) {
            return All.Where(x => ids.Contains(x.Id));
        }
    }
}