using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Models
{

    public static class MovieRepository
    {

        public static List<Movie> movies = new List<Movie>
    {
    new Movie { Id = 1, Title = "Indiana Jones and the Quest for the Missing Remote", Director = "Steven Spielberger", Genre = "Adventure", Year = 2023, Synopsis = "The famed archaeologist hunts for the world's most elusive artifact: the TV remote.", Tags = new List<string> { "Action", "Humor", "Adventure" } },
    new Movie { Id = 2, Title = "Lord of the Fries", Director = "Peter Jackman", Genre = "Comedy", Year = 2021, Synopsis = "A fast-food epic about the battle to create the best French fry recipe in Middle-Earth.", Tags = new List<string> { "Fast Food", "Fantasy", "Epic" } },
    new Movie { Id = 3, Title = "The Devil Wears Nada", Director = "Anne Hathaback", Genre = "Comedy", Year = 2019, Synopsis = "A fashion novice lands a job with a nudist magazine editor-in-chief.", Tags = new List<string> { "Fashion", "Comedy", "Satire" } },
    new Movie { Id = 4, Title = "Harry Potter and the Chamber of Commerce", Director = "Chris Columbus", Genre = "Fantasy", Year = 2020, Synopsis = "Harry navigates the most mysterious place yet: the world of wizarding business.", Tags = new List<string> { "Magic", "Business", "Fantasy" } },
    new Movie { Id = 5, Title = "Bat Guy Begins", Director = "Chris Nolant", Genre = "Action", Year = 2022, Synopsis = "An ordinary man decides to become a superhero, with nothing but a bat costume and sheer enthusiasm.", Tags = new List<string> { "Superhero", "Origin Story", "Comedy" } },
    new Movie { Id = 6, Title = "Gone with the Wifi", Director = "Victor Flemingstone", Genre = "Drama", Year = 2024, Synopsis = "A gripping tale of survival in a world where the internet has mysteriously disappeared.", Tags = new List<string> { "Survival", "Drama", "Mystery" } },
    new Movie { Id = 7, Title = "Jurassic Parkour", Director = "Steven Spielberger", Genre = "Action", Year = 2018, Synopsis = "Dinosaurs learn parkour and take over an island, leading to high-flying chases.", Tags = new List<string> { "Dinosaurs", "Parkour", "Adventure" } },
    new Movie { Id = 8, Title = "The Breakfast Blub", Director = "John Huge", Genre = "Drama", Year = 2025, Synopsis = "A group of fish in an aquarium bond over shared meals and adventures.", Tags = new List<string> { "Aquatic", "Friendship", "Family" } },
    new Movie { Id = 9, Title = "The Shawshank Redemption: Escape to the Beach", Director = "Frank Darabout", Genre = "Drama", Year = 2023, Synopsis = "After escaping prison, Andy and Red start a beachside resort for former inmates.", Tags = new List<string> { "Escape", "Beach Life", "Redemption" } },
    new Movie { Id = 10, Title = "Ghost Posters", Director = "Ivan Reitghost", Genre = "Comedy", Year = 2022, Synopsis = "A team of goofy ghosts starts a business creating spooky advertisements.", Tags = new List<string> { "Ghost", "Comedy", "Business" } },
    new Movie { Id = 11, Title = "The Grand Budapest Motel", Director = "Wes Andersonville", Genre = "Comedy", Year = 2021, Synopsis = "The quirky staff of a budget motel embarks on a comical adventure to save their establishment.", Tags = new List<string> { "Quirky", "Adventure", "Comedy" } },
    new Movie { Id = 12, Title = "Raiders of the Lost Bark", Director = "Steven Spielberger", Genre = "Adventure", Year = 2019, Synopsis = "Adventurous pups embark on a journey to find the mystical tree of infinite treats.", Tags = new List<string> { "Adventure", "Animals", "Family" } },
    new Movie { Id = 13, Title = "Guardians of the Galley", Director = "James Gunner", Genre = "Sci-Fi", Year = 2020, Synopsis = "A group of intergalactic chefs protects the universe using culinary skills and kitchen gadgets.", Tags = new List<string> { "Sci-Fi", "Culinary", "Action" } },
    new Movie { Id = 14, Title = "Dial M for Marmalade", Director = "Alfred Hitchockatoo", Genre = "Mystery", Year = 2024, Synopsis = "A thrilling hunt for a secret marmalade recipe that grants eternal youth.", Tags = new List<string> { "Mystery", "Thriller", "Culinary" } },
    new Movie { Id = 15, Title = "Star Wars: The Empire Stripes Back", Director = "George Lucid", Genre = "Sci-Fi", Year = 2025, Synopsis = "The Empire enforces a galaxy-wide fashion change to stripes, sparking rebellion.", Tags = new List<string> { "Sci-Fi", "Rebellion", "Fashion" } },
    new Movie { Id = 16, Title = "A Clockwork Orange Juice", Director = "Stanley Cubebrick", Genre = "Drama", Year = 2023, Synopsis = "A tale of a man's obsession with finding the perfect orange for his morning juice.", Tags = new List<string> { "Drama", "Obsession", "Culinary" } },
    new Movie { Id = 17, Title = "Reservoir Frogs", Director = "Quentin Tarrapin", Genre = "Crime", Year = 2022, Synopsis = "A group of amphibian criminals attempts the heist of the century: stealing the world's largest lily pad.", Tags = new List<string> { "Crime", "Heist", "Comedy" } },
    new Movie { Id = 18, Title = "To Kale a Mockingbird", Director = "Harper Leefood", Genre = "Drama", Year = 2021, Synopsis = "A small town lawyer faces prejudice and challenges while defending a misunderstood kale farmer.", Tags = new List<string> { "Drama", "Law", "Social Issues" } },
    new Movie { Id = 19, Title = "The Wizard of Ooze", Director = "Victor Flemingstone", Genre = "Fantasy", Year = 2020, Synopsis = "A young girl's surreal journey through a land filled with mysterious goo and slime.", Tags = new List<string> { "Fantasy", "Adventure", "Mystery" } },
    new Movie { Id = 20, Title = "Crouching Tiger, Hidden Dragonfruit", Director = "Ang Leefruit", Genre = "Action", Year = 2019, Synopsis = "Martial artists embark on a quest to find a mythical fruit said to grant extraordinary powers.", Tags = new List<string> { "Action", "Martial Arts", "Mythical" } }
    };

        public static List<Movie> moviesResults = new List<Movie>();

        public static void AddMovie(Movie movie)
        {
            // Check if the Movies collection already contain any movies.
            if (movies.Any())
            {
                // If there are existing movies, set the new movie's ID to one more than the highest current ID.
                movie.Id = movies.Max(i => i.Id) + 1;
            }
            else
            {
                // If the collection is empty, initialize the first movie with an ID of 1.
                movie.Id = 1;
            }

            // Adds the new movie to the Movies collection.
            movies.Add(movie);
        }

        public static Movie GetMovieById(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);
        }

        public static List<Movie> filteredMovies = new List<Movie>();
        public static void AddFilter(Movie movie)
        {
            filteredMovies.Add(movie);
        }
    }
}

