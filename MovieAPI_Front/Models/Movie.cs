using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieAPI_Front.Models
{
    public class Movie
    {

        [Key]
        public string MovieId { get; set; }
        [Required]
        [Display(Name = "Movie Title")]
        public string MovieTitle { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(250)]
        [Required]
        public string Poster { get; set; }

        public Movie() { }

        public Movie(string movieId, string movieTitle, string year, string director, string description, string poster)
        {
            MovieId = movieId;
            MovieTitle = movieTitle;
            Year = year;
            Director = director;
            Description = description;
            Poster = poster;
        }
    }
}
