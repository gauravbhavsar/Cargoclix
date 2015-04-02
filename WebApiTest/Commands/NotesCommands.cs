using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Commands {
    public interface INotesCommand {

    }

    public class NotesCreateCommand:ICreateCommand, INotesCommand {
        public string Comment { get; set; }
        public int ScheduleId { get; set; }
    }

    public class NotesUpdateCommand:IUpdateCommand<int>, INotesCommand {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int ScheduleId { get; set; }
    }

    public class NotesDeleteCommand:IDeleteCommand<int>, INotesCommand {
        public int Id { get; set; }
    }
}