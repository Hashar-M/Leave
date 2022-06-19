using System.ComponentModel.DataAnnotations;

namespace Leave.Models
{
    //public class Create_Leave_type_view_model
    //{
        
        
    //    [Required]                      // required when adding
    //    public string Name { get; set; }
        

    //}

    public class Leave_type_view_model
    {

        public int Id { get; set; }
        [Required]
        [Display(Name ="Leave Types")]
        public string Name { get; set; }
        [Display(Name=" Date Created")]
        public DateTime? Date_created { get; set; }          // not required bcz it is auto fill

    }
}

