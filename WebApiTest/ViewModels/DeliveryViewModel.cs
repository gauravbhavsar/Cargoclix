using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.ViewModels {

    public class DeliveryViewModel {
        public int Id { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime deliveredTime { get; set; }
        public string deliveredTo { get; set; }
    }

    public class DeliveryCreateViewModel {
        public bool IsDelivered { get; set; }
        public DateTime deliveredTime { get; set; }
        public string deliveredTo { get; set; }
    }

    public class DeliveryUpdateViewModel {
        public int Id { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime deliveredTime { get; set; }
        public string deliveredTo { get; set; }
    }

    public class DeliveryDeleteViewModel {
        public int Id { get; set; }
    }
}