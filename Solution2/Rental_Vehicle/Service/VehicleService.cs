using Rental_Vehicle.Models;
using Rental_Vehicle.Repository;

namespace Rental_Vehicle.Service
{
    public class VehicleService : IVehicleService
    {
        public IVehiclerepository _vehicleRepository;
        public VehicleService(IVehiclerepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<int> AddVehicle(Vehicle vehicle)
        {
            var addedVehicle = await _vehicleRepository.AddVehicle(vehicle);
            return addedVehicle;

        }

        public async Task<Vehicle> GetVehicleById(int Id)
        {

            var vehicle = await _vehicleRepository.GetVehicleById(Id);
            if (vehicle == null)
            {
                throw new Exception("Vehicle does not exist");
            }
            return vehicle;

        }

        public async Task<int> DeleteVehicleById(Vehicle vehicle)
        {
            var delete = await _vehicleRepository.DeleteVehicleById(vehicle);
            return delete;

        }

        public async Task<int> UpdateVehicleById(int id, Vehicle vehicle)
        {
            var exist = await this.GetVehicleById(id);

            var updateById = await _vehicleRepository.UpdateVehicleById(id, vehicle);
            return updateById;
        }
        public async Task<IEnumerable<Vehicle>> GetAllVehicle()
        {
            return await _vehicleRepository.GetAllVehicle();
        }
    }
}
