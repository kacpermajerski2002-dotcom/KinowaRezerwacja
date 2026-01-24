using System;
using System.ComponentModel.DataAnnotations;

namespace KinowaRezerwacja.Models
{
    public class Seance
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        public int HallId { get; set; }
        public Hall Hall { get; set; } = null!;
    }
}
