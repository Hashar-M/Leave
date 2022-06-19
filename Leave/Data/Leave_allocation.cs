using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leave.Data
{
    public class Leave_allocation
    {
        [Key]
        public int Id { get; set; }
        public int Number_of_Days { get; set; }
        public DateTime Date_created { get; set; }

        [ForeignKey("Emp_Id")]
        public Employee Employee { get; set; }
        public string Emp_Id { get; set; }

        [ForeignKey("Leave_type_id")]
        public Leave_type Leave_type { get; set; }
        public int Leave_type_id { get; set; }


    }
}
