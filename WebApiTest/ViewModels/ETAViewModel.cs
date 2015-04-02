using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiTest.Models;

namespace WebApiTest.ViewModels {
    public class ETAViewModel {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public DateTime When { get; set; }
        public string Reason { get; set; }
        public ReasonEnum ReasonEnum { get; set; }
    }
    public class ETACreateViewModel {
        public int DeliveryId { get; set; }
        public DateTime When { get; set; }
        public string Reason { get; set; }
        public ReasonEnum ReasonEnum { get; set; }
    }

    public class ETAUpdateViewModel {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public DateTime When { get; set; }
        public string Reason { get; set; }
        public ReasonEnum ReasonEnum { get; set; }
    }

    public class ETADeleteViewModel {
        public int Id { get; set; }
    }
}