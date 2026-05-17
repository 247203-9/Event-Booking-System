namespace EventBookingSystem.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime EventDate { get; set; } = DateTime.Now.AddDays(7);
        public string Venue { get; set; } = string.Empty;
        public int TotalCapacity { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
    }
}