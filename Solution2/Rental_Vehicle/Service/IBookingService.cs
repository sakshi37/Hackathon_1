using Rental_Vehicle.Models;

namespace Rental_Vehicle.Service
{
    public interface IBookingService
    {

        Task<int> BookVehicle(Booking booking);
        Task<ICollection<Booking>> GetBookingByUserId(int userId);
    }
}
