using Microsoft.EntityFrameworkCore;
using Rental_Vehicle.Context;
using Rental_Vehicle.Models;

namespace Rental_Vehicle.Repository
{
    public class VehicleRepository : IVehiclerepository
    {
        public UserDbContext _vehicleDbContext;
        public VehicleRepository(UserDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }
        public async Task<int> AddVehicle(Vehicle vehicle)
        {
            await _vehicleDbContext.vehicles.AddAsync(vehicle);
            var temp = await _vehicleDbContext.SaveChangesAsync();
            Console.WriteLine(vehicle.Brand, vehicle.VehicleId);
            return temp;
        }
        public async Task<Vehicle?> GetVehicleById(int vehicleId)
        {
            var getVehicleById = await _vehicleDbContext.vehicles.FirstOrDefaultAsync(i => i.VehicleId == vehicleId);
            return getVehicleById;
        }

        public async Task<int> DeleteVehicleById(Vehicle vehicle)
        {

            _vehicleDbContext.vehicles.Remove(vehicle);
            return await _vehicleDbContext.SaveChangesAsync();


        }

        public async Task<int> UpdateVehicleById(int id, Vehicle vehicle)
        {
            _vehicleDbContext.vehicles.Update(vehicle);
            return await _vehicleDbContext.SaveChangesAsync();


        }
        public async Task<IEnumerable<Vehicle>> GetAllVehicle()
        {
            return await _vehicleDbContext.vehicles.ToListAsync();
        }

    }
}
