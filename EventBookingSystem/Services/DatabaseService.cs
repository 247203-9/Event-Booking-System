using EventBookingSystem.Models;

namespace EventBookingSystem.Services
{
    public class DatabaseService
    {
        public List<Event> Events { get; set; } = new();
        public List<Booking> Bookings { get; set; } = new();
        public List<string> Feedbacks { get; set; } = new();

        // New Feature Variable: Track Ratings for each Event ID
        public Dictionary<int, List<int>> EventRatings { get; set; } = new();

        public DatabaseService()
        {
            Events.Add(new Event { Id = 1, Title = "National AI & Robotics Summit 2026", Description = "Exclusive workshop on Deep Learning and Generative AI models.", Venue = "Main Auditorium, Air University", TotalCapacity = 150, AvailableSeats = 142, TicketPrice = 2500.00m, EventDate = DateTime.Now.AddDays(2) }); // 2 days left (Urgent trigger)
            Events.Add(new Event { Id = 2, Title = "Premium Musical Concert & Sufi Night", Description = "An enchanting evening featuring legendary classical and sufi artists.", Venue = "Central Campus Sports Grounds", TotalCapacity = 500, AvailableSeats = 480, TicketPrice = 4000.00m, EventDate = DateTime.Now.AddDays(12) });
            Events.Add(new Event { Id = 3, Title = "International Tech Hackathon", Description = "48-hour continuous software engineering sprint with internship pools.", Venue = "CS Labs, Block C", TotalCapacity = 80, AvailableSeats = 12, TicketPrice = 1500.00m, EventDate = DateTime.Now.AddDays(1) }); // 1 day left (Urgent trigger)
            Events.Add(new Event { Id = 4, Title = "Cyber Security & Ethical Hacking BootCamp", Description = "Live penetration testing simulation and network defense strategy lab sessions.", Venue = "Digital Forensic Lab", TotalCapacity = 60, AvailableSeats = 45, TicketPrice = 1800.00m, EventDate = DateTime.Now.AddDays(7) });
            Events.Add(new Event { Id = 5, Title = "Annual Career Expo & Corporate Networking", Description = "Meet HR leads from 50+ top tech companies and multinationals for direct hiring.", Venue = "Gymnasium Hall", TotalCapacity = 300, AvailableSeats = 295, TicketPrice = 500.00m, EventDate = DateTime.Now.AddDays(15) });
            Events.Add(new Event { Id = 6, Title = "Data Science with Python Masterclass", Description = "End-to-end data pipelines, cleaning, visualization, and deployment workflows.", Venue = "Video Conferencing Room", TotalCapacity = 40, AvailableSeats = 0, TicketPrice = 1200.00m, EventDate = DateTime.Now.AddDays(5) });
            Events.Add(new Event { Id = 7, Title = "E-Gaming Championship (Valorant & FIFA)", Description = "Inter-university gaming league with massive prize pool and live streaming gear.", Venue = "Student Cafeteria Lounge", TotalCapacity = 120, AvailableSeats = 8, TicketPrice = 1000.00m, EventDate = DateTime.Now.AddDays(9) });
            Events.Add(new Event { Id = 8, Title = "Seminar on Cloud Native Computing (AWS/GCP)", Description = "Moving monolith structures to Docker containers and Kubernetes clusters architecture.", Venue = "Main Auditorium, Air University", TotalCapacity = 200, AvailableSeats = 185, TicketPrice = 2200.00m, EventDate = DateTime.Now.AddDays(20) });

            // Initialize default ratings for rich data presentation
            foreach (var ev in Events)
            {
                EventRatings[ev.Id] = new List<int> { 5, 4, 5 }; // Seed initial 4.6 average rating
            }

            Feedbacks.Add("Ali: Amazing management infrastructure model!");
        }

        public double GetAverageRating(int eventId)
        {
            if (!EventRatings.ContainsKey(eventId) || !EventRatings[eventId].Any()) return 0.0;
            return Math.Round(EventRatings[eventId].Average(), 1);
        }

        public bool CreateBooking(Booking newBooking)
        {
            var targetEvent = Events.FirstOrDefault(e => e.Id == newBooking.EventId);
            if (targetEvent == null || targetEvent.AvailableSeats < newBooking.SeatsBooked)
            {
                return false;
            }

            targetEvent.AvailableSeats -= newBooking.SeatsBooked;
            newBooking.Id = Bookings.Count + 1;
            Bookings.Add(newBooking);
            return true;
        }
    }
}