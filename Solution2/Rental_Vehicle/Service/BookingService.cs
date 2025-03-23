using Rental_Vehicle.Models;
using Rental_Vehicle.Repository;
namespace Rental_Vehicle.Service
{
    public class BookingService : IBookingService
    {
        public IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)

        {
            _bookingRepository = bookingRepository;
        }

        public async Task<int> BookVehicle(Booking booking)
        {
            var addedBooking = await _bookingRepository.BookVehicle(booking);
            return addedBooking;
        }
        public async Task<ICollection<Booking>> GetBookingByUserId(int userId)
        {
            var user = await _bookingRepository.GetBookingByUserId(userId);
            return user;
        }

    }
}
