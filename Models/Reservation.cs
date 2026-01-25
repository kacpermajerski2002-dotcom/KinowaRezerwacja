using System.ComponentModel.DataAnnotations;

namespace KinowaRezerwacja.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public int SeanceId { get; set; }
        public Seance Seance { get; set; } = null!;

        [Required]
        public int SeatId { get; set; }
        public Seat Seat { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        public DateTime ReservationDate { get; set; } = DateTime.Now;
    }
}
