using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Commands {
    public interface IDeliveryCommand {

    }

    public class DeliveryCreateCommand:ICreateCommand, IDeliveryCommand {
        public bool IsDelivered { get; set; }
        public DateTime deliveredTime { get; set; }
        public string deliveredTo { get; set; }
    }

    public class DeliveryUpdateCommand:IUpdateCommand<int>, IDeliveryCommand {
        public int Id { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime deliveredTime { get; set; }
        public string deliveredTo { get; set; }
    }

    public class DeliveryDeleteCommand:IDeleteCommand<int>, IDeliveryCommand {
        public int Id { get; set; }
    }
}