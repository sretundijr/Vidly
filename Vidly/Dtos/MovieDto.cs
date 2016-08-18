using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        [Range(1, int.MaxValue)]
        public int QtyInStock { get; set; }

        [Required]
        public byte MovieGenreId { get; set; }

        public MovieGenreDto Genre { get; set; }


    }
}