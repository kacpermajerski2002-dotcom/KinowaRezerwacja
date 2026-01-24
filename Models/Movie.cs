using System;
using System.ComponentModel.DataAnnotations;

namespace KinowaRezerwacja.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(100)]
        public required string Title { get; set; }

        public required string Description { get; set; }

        [Range(1, 400)]
        public int Duration { get; set; }

    }
}
