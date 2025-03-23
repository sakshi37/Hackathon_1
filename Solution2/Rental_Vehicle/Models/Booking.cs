namespace Rental_Vehicle.Models
{
    public class Booking
    {
        //BookingId
        //VehicleId
        //UserId
        //StartDate
        //EndDate
        //TotalAmount
        //Vehicle Vehicle // Navigation Property 
        //User User // Navigation Property

        public int BookingId { get; set; }
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalAmount { get; set; }


        public ICollection<User> User { get; set; }
        public ICollection<Vehicle> Vehicle { get; set; }

        //public Payment Payment { get; set; }
    }
}
