using System.ComponentModel.DataAnnotations;

namespace KinowaRezerwacja.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public required Movie Movie { get; set; }

        public int SeatId { get; set; }
        public required Seat Seat { get; set; }

        public required string UserId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
