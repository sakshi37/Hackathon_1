namespace Rental_Vehicle.Models
{
    public class Vehicle
    {
        // VehicleId  
        // Model  
        // Brand  
        // Type // SUV, Sedan, Bike, etc. 
        // RentalPricePerDay  
        // IsAvailable

        public int VehicleId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int RentalPricePerDay { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }

}
