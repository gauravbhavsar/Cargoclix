using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiTest.Models {
    public class Schedule {
        public int Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime When { get; set; }

        [StringLength(500)]
        public string Task { get; set; }
        
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
        
        public Driver Driver { get; set; }
        public int? DriverId { get; set; }

        public IList<Notes> Notes { get; set; }
    }

    public class Driver:ApplicationUser {
        public IList<Schedule> Schedules { get; set; }
    }

    public class Owner:ApplicationUser {
        public IList<Schedule> Schedules { get; set; }
    }
}