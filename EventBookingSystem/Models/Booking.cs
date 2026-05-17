namespace EventBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public int SeatsBooked { get; set; }
        public decimal TotalPaid { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}