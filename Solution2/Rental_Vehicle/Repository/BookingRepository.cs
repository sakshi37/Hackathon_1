using Microsoft.EntityFrameworkCore;
using Rental_Vehicle.Context;
using Rental_Vehicle.Models;

namespace Rental_Vehicle.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public UserDbContext _bookingDbContext;
        public BookingRepository(UserDbContext bookingRepository)
        {
            _bookingDbContext = bookingRepository;
        }

        public async Task<int> BookVehicle(Booking booking)
        {
            await _bookingDbContext.bookings.AddAsync(booking);
            return await _bookingDbContext.SaveChangesAsync();

        }

        public async Task<ICollection<Booking>> GetBookingByUserId(int userId)
        {
            var booking = await _bookingDbContext.bookings.ToListAsync();
            return booking;
        }
    }
}
