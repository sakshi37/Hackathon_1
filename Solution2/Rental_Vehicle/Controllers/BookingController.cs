using Microsoft.AspNetCore.Mvc;
using Rental_Vehicle.Models;
using Rental_Vehicle.Service;

namespace Rental_Vehicle.Controllers
{
    public class BookingController : Controller
    {
        public IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {

            _bookingService = bookingService;
        }
        public IActionResult BookVehicle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookVehicle(Booking booking)
        {
            Console.WriteLine("booking id: ", booking.BookingId.ToString());
            Console.WriteLine("user id: ", booking.UserId.ToString());
            Console.WriteLine("vehicle id: ", booking.VehicleId.ToString());
            var bookVehicle = await _bookingService.BookVehicle(booking);
            return RedirectToAction("GetBookingByUserId");
        }

        public async Task<IActionResult> GetBookingByUserId(int userId)
        {
            var getBook = await _bookingService.GetBookingByUserId(userId);
            return View(getBook);
        }
    }
}
