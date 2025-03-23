using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rental_Vehicle.Models;

namespace Rental_Vehicle.Context
{
    public class UserDbContext : IdentityDbContext<User>
    {
        public UserDbContext(DbContextOptions<UserDbContext> option) : base(option)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Booking> bookings { get; set; }

    }
}
