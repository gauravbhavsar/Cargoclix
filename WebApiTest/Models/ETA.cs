using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Models {
    public class ETA {
        public int Id { get; set; }

        public Delivery Delivery{ get; set;}
        public int DeliveryId { get; set; }

        public DateTime When { get; set; }
        public string Reason { get; set; }
        public ReasonEnum ReasonEnum { get; set; }

    }

    public enum ReasonEnum {
        I_am_on_my_way=0,
        Report_a_delay=1,
    }
}