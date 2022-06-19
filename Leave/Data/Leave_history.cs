using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leave.Data
{
    public class Leave_history
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RequestingEmplId")] 
        public Employee Requesting_employee { get; set; }
        public string? RequestingEmplId { get; set; }           //allowing nullable
       
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }

        [ForeignKey("LeaveTypId")]
        public Leave_type Leave_type { get; set; }
        public int LeaveTypId { get; set; }

        public DateTime Date_requested { get; set; }
        public DateTime Date_actioned { get; set; }

        public bool? Approved { get; set; }             // value related to date_actioned

        [ForeignKey("ApprovedById")]              //primery key of employee will taken as primery key
        public Employee Approved_by { get; set; }
        public string ApprovedById { get; set; }
    }
}
