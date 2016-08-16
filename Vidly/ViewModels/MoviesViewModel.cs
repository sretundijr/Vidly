using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesViewModel
    {
        public MoviesViewModel()
        {
            Id = 0;
        }

        public MoviesViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            QtyInStock = movie.QtyInStock;
            MovieGenreId = movie.MovieGenreId;    
        }

        public int? Id { get; set; }

        [Required]
        [Display(Name = "Movie Title")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Quantity in stock must be greater then 0")]
        [Display(Name = "Quantity in Stock")]
        public int? QtyInStock { get; set; }

        [Required]
        [Display(Name = "Genre Type")]
        public byte? MovieGenreId { get; set; }

        public List<Movie> MoviesList { get; set; }
        public IEnumerable<MovieGenre> MovieGenre { get; set; }

        public string Title
        {
            get
            {
                if(Id != 0)
                {
                    return "Edit Movie";
                }
                else
                {
                    return "New Movie";
                }
            }
        }
    }
}