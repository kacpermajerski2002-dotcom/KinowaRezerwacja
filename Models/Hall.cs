using System.ComponentModel.DataAnnotations;

namespace KinowaRezerwacja.Models
{
    public class Hall
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        [Range(1, 20)]
        public int Rows { get; set; }

        [Range(1, 30)]
        public int SeatsPerRow { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();

    }
}
