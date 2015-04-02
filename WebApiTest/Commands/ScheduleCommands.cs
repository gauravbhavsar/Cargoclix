using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Commands {
    public interface IScheduleCommand {

    }

    public class ScheduleCreateCommand:ICreateCommand, IScheduleCommand {
        public DateTime Created { get; set; }
        public DateTime When { get; set; }
        public string Task { get; set; }
        public int OwnerId { get; set; }
        public int? DriverId { get; set; }
    }

    public class ScheduleUpdateCommand:IUpdateCommand<int>, IScheduleCommand {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime When { get; set; }
        public string Task { get; set; }
        public int OwnerId { get; set; }
        public int? DriverId { get; set; }      
    }

    public class ScheduleDeleteCommand:IDeleteCommand<int>, IScheduleCommand {
        public int Id { get; set; }
    }
}