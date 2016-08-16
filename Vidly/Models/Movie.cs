using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Movie Title")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime AddedToInventory { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Quantity in stock must be greater then 0")]
        [Display(Name = "Quantity in Stock")]
        public int QtyInStock { get; set; }

        public MovieGenre Genre { get; set; }

        [Required]
        [Display(Name = "Genre Type")]
        public byte MovieGenreId { get; set; }

    }
}