using Rental_Vehicle.Models;

namespace Rental_Vehicle.Repository
{
    public interface IVehiclerepository
    {
        //Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle?> GetVehicleById(int vehicleId);
        Task<int> AddVehicle(Vehicle vehicle);
        Task<int> UpdateVehicleById(int id, Vehicle vehicle);
        Task<int> DeleteVehicleById(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetAllVehicle();
        //Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync();
    }
}
