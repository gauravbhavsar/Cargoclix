using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Models {
    public class Delivery : Schedule {
        public bool IsDelivered { get; set; }
        public DateTime deliveredTime { get; set; }
        public string deliveredTo { get; set; }

        public IList<ETA> ETAs { get; set; }
    }
}