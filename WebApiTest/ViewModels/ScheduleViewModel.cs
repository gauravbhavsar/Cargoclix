using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.ViewModels {

    public class ScheduleViewModel {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime When { get; set; }
        public string Task { get; set; }
        public int OwnerId { get; set; }
        public int? DriverId { get; set; }
    }

    public class ScheduleCreateViewModel {
        public DateTime Created { get; set; }
        public DateTime When { get; set; }
        public string Task { get; set; }
        public int OwnerId { get; set; }
        public int? DriverId { get; set; }
    }

    public class ScheduleUpdateViewModel {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime When { get; set; }
        public string Task { get; set; }
        public int OwnerId { get; set; }
        public int? DriverId { get; set; }
    }

    public class ScheduleDeleteViewModel {
        public int Id { get; set; }
    }
}