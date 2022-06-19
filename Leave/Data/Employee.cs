using Microsoft.AspNetCore.Identity;

namespace Leave.Data
{
    public class Employee: IdentityUser
    {
        public string First_name { get; set; }
        public string Last_Name { get; set; }
        public string Tax_id { get; set; }
        public DateTime Date_of_birth { get; set; }
        public DateTime Date_joined { get; set; }

    }
}
