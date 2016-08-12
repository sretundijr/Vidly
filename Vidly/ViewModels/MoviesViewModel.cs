using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesViewModel
    {
        public Movie Movie { get; set; }
        public List<Movie> MoviesList { get; set; }
        public IEnumerable<MovieGenre> MovieGenre { get; set; }

        public string Title
        {
            get
            {
                if(Movie != null && Movie.Id != 0)
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