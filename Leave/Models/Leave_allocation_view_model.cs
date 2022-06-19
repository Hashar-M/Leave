using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Leave.Models
{
    public class Leave_allocation_view_model
    {
        public int Id { get; set; }
        [Required]
        public int Number_of_Days { get; set; }
        public DateTime Date_created { get; set; }

        
        public Employee_view_model Employee { get; set; } // from drop down
        public string Emp_Id { get; set; }

        
        public Leave_type_view_model Leave_type { get; set; }
        public int Leave_type_id { get; set; }

        public IEnumerable<SelectListItem> Leave_types { get; set; }
        public IEnumerable<SelectListItem> employees { get; set; }
    }
}
