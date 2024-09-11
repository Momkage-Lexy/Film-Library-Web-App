using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models{

    public class Movie
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        [Required(ErrorMessage = "Synopsis is required")]
        public string Synopsis { get; set; }

        public List<string> Tags { get; set;}

        public override string ToString()
        {
            return $"{Id}.png";
        }
    }
}
