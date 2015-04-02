using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiTest.Models;

namespace WebApiTest.Commands {
    public interface IETACommand {

    }

    public class ETACreateCommand:ICreateCommand, IETACommand {
        public int DeliveryId { get; set; }
        public DateTime When { get; set; }
        public string Reason { get; set; }
        public ReasonEnum ReasonEnum { get; set; }
    }

    public class ETAUpdateCommand:IUpdateCommand<int>, IETACommand {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public DateTime When { get; set; }
        public string Reason { get; set; }
        public ReasonEnum ReasonEnum { get; set; }
    }

    public class ETADeleteCommand:IDeleteCommand<int>, IETACommand {
        public int Id { get; set; }
    }
}