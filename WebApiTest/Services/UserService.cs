using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiTest.Commands;
using WebApiTest.Models;

namespace WebApiTest.Services {
    public interface IUserService:IDataService<ApplicationUser, int, UserUpdateCommand, UserCreateCommand, UserDeleteCommand> {

    }

    public class UserService:DataServiceBase<ApplicationUser, int, UserUpdateCommand, UserCreateCommand, UserDeleteCommand>, IUserService {

        protected override Repository.IRepository<ApplicationUser, int> Repository {
            get { throw new NotImplementedException(); }
        }

        public override ApplicationUser CommandToEntity(UserCreateCommand command) {
            throw new NotImplementedException();
        }

        public override ApplicationUser CommandToEntity(UserUpdateCommand command, ApplicationUser entity) {
            throw new NotImplementedException();
        }
    }
}