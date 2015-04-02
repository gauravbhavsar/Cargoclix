using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.ViewModels {
    public class NotesViewModel {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int ScheduleId { get; set; }
    }

    public class NotesCreateViewModel {
        public string Comment { get; set; }
        public int ScheduleId { get; set; }
    }

    public class NotesUpdateViewModel {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int ScheduleId { get; set; }
    }

    public class NotesDeleteViewModel {
        public int Id { get; set; }
    }
}