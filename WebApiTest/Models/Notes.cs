using System.ComponentModel.DataAnnotations;

namespace WebApiTest.Models {
    public class Notes {
        public int Id { get; set; }

        [StringLength(100)]
        public string Comment { get; set; }

        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }
    }
}