using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Commands {
    public interface IUserCommand {

    }

    public class UserCreateCommand:ICreateCommand, IUserCommand {

    }

    public class UserUpdateCommand:IUpdateCommand<int>, IUserCommand {
        public int Id { get; set; }
    }

    public class UserDeleteCommand:IDeleteCommand<int>, IUserCommand {
        public int Id { get; set; }
    }
}