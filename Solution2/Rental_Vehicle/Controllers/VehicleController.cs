using Microsoft.AspNetCore.Mvc;
using Rental_Vehicle.Models;
using Rental_Vehicle.Service;

namespace Rental_Vehicle.Controllers
{
    public class VehicleController : Controller
    {
        public readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        public IActionResult AddVehicle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(Vehicle vehicle)
        {
            await _vehicleService.AddVehicle(vehicle);
            return RedirectToAction("GetAllVehicle");
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleById(int vehicleId)
        {
            try
            {
                var vehicle = await _vehicleService.GetVehicleById(vehicleId);
                return View(vehicle);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View(ex.Message);
            }
        }

        //public async Task<IActionResult> DeleteVehicleById(Vehicle vehicle)
        //{
        //    var deleteById = await _vehicleService.DeleteVehicleById(vehicle);
        //    return View(deleteById);
        //}

        public async Task<IActionResult> GetAllVehicle()
        {
            var allVehicle = await _vehicleService.GetAllVehicle();
            return View("GetAllVehicle", allVehicle);
        }

        public IActionResult UpdateVehicleById()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVehicleById(int id, Vehicle vehicle)
        {
            var update = await _vehicleService.UpdateVehicleById(id, vehicle);
            return View("UpdateVehicleById", update);
        }
    }
}
