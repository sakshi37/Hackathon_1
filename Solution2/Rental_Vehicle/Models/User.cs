using Microsoft.AspNetCore.Identity;

namespace Rental_Vehicle.Models
{
    public class User : IdentityUser
    {
        //        UserId  
        // Name  
        // Email  
        // Password  
        // Role("Admin" or "Customer")
        // // Navigation Property 
        // List<Booking> Bookings

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
