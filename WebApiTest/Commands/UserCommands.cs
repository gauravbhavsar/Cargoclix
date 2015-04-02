using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Commands {
    public interface IOwnerCommand {

    }

    public class OwnerCreateCommand:ICreateCommand, IOwnerCommand {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class OwnerUpdateCommand:IUpdateCommand<int>, IOwnerCommand {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }

    public class OwnerDeleteCommand:IDeleteCommand<int>, IOwnerCommand {
        public int Id { get; set; }
    }

    public class IDriverCommand {

    }

    public class DriverCreateCommand:ICreateCommand, IOwnerCommand {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }

    public class DriverUpdateCommand:IUpdateCommand<int>, IOwnerCommand {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }

    public class DriverDeleteCommand:IDeleteCommand<int>, IOwnerCommand {
        public int Id { get; set; }
    }
}