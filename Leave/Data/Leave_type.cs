using System.ComponentModel.DataAnnotations;

namespace Leave.Data
{
    public class Leave_type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date_created { get; set; }

    }
}
