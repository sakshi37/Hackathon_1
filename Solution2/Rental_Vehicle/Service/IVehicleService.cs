using Rental_Vehicle.Models;

namespace Rental_Vehicle.Service
{
    public interface IVehicleService
    {
        Task<int> AddVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleById(int Id);
        //Task<int> DeleteVehicleById(int vehicleId);

        Task<int> UpdateVehicleById(int id, Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetAllVehicle();
    }
}
