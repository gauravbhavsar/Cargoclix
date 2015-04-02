using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiTest.Models;

namespace WebApiTest.Repository {
    public interface IUserRepository:IRepository<ApplicationUser, int> {

    }

    public class UserRepository:EfRepository<ApplicationUser, int>, IUserRepository {

        public UserRepository(IApplicationDataContext context)
            : base(context) {}

        public override IQueryable<ApplicationUser> ById(IEnumerable<int> ids) {
            return All.Where(x => ids.Contains(int.Parse(x.Id)));
        }
    }
}