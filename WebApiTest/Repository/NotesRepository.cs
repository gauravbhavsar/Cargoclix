using System.Collections.Generic;
using System.Linq;
using WebApiTest.Models;

namespace WebApiTest.Repository {
    public interface INotesRepository:IRepository<Notes, int> {

    }
    public class NotesRepository:EfRepository<Notes, int>, INotesRepository {
        public NotesRepository(IApplicationDataContext context)
            : base(context) { }

        public override IQueryable<Notes> ById(IEnumerable<int> ids) {
            return All.Where(x => ids.Contains(x.Id));
        }
    }
}