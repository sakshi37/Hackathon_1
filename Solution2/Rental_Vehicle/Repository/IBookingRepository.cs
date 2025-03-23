using Rental_Vehicle.Models;

namespace Rental_Vehicle.Repository
{
    public interface IBookingRepository
    {

        Task<int> BookVehicle(Booking booking);

        Task<ICollection<Booking>> GetBookingByUserId(int userId);
    }
}
