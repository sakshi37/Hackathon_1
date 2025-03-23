namespace Rental_Vehicle.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
        //public int BookingId { get; set; }
        //public ICollection<Booking> Bookings { get; set; }
    }
}
