using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Leave.Models
{
    public class leave_history_view_model
    {
        [Key]
        public int Id { get; set; }

        
        public Employee_view_model Requesting_employee { get; set; }
        public string? RequestingEmplId { get; set; }           //allowing nullable
        [Required]
        public DateTime Start_date { get; set; }
        [Required]
        public DateTime End_date { get; set; }

        
        public Leave_type_view_model Leave_type { get; set; }
        public int LeaveTypId { get; set; }

        public DateTime Date_requested { get; set; }
        public DateTime Date_actioned { get; set; }

        public bool? Approved { get; set; }             // value related to date_actioned

                     //primery key of employee will taken as primery key
        public Employee_view_model Approved_by { get; set; }
        public string ApprovedById { get; set; }

        public IEnumerable<SelectListItem> Leave_types { get; set; }

    }
}
