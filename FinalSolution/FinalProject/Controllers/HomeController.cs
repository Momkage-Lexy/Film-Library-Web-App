using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using Microsoft.AspNetCore.Http.Features;

namespace FinalProject.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.accountCount = AccountRepository.profile.Count;
        return View();
    }

    // Field to hold the web hosting environment information
    private readonly IWebHostEnvironment _hostingEnvironment;

    // Constructor to inject the IWebHostEnvironment dependency
    public HomeController(IWebHostEnvironment hostingEnvironment)
    {
        // Assign the injected hosting environment to the private field
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult MovieView(Account account)
    {
        // Check if the UserName property of the account object is not null
        if (account.UserName != null)
        {
            // Check if the Icon property of the account object is not an empty string
            if (!string.IsNullOrEmpty(account.Icon))
            {
                // Convert the Base64 string from the Icon property to a byte array
                byte[] imageBytes = Convert.FromBase64String(account.Icon.Split(',')[1]);

                // Define the folder path for storing images, combining the web root path and the 'images' directory
                string folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                // Construct the file name using the UserName property
                string fileName = $"{account.UserName}.png";

                // Combine the folder path and file name to create the full file path
                string filePath = Path.Combine(folderPath, fileName);

                // Check if the directory for storing images exists, if not, create it
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Write the byte array as an image file to the specified file path
                System.IO.File.WriteAllBytes(filePath, imageBytes);

                // Update the Icon property to store just the file name, not the Base64 string
                account.Icon = fileName;
            }
            AccountRepository.RemoveProfile();
            AccountRepository.AddProfile(account);
        }

        // Check if the profile count in the repository is zero
        if (AccountRepository.profile.Count == 0)
        {
            TempData["AlertMessage"] = "You must sign in to access this page.";
        }
        var filteredMovies = new List<Movie>();
        filteredMovies.Clear();
        if (account.Favorites != null && account.Favorites.Any())
        {
            foreach (var movie in MovieRepository.movies)
            {
                if (movie.Genre != null && account.Favorites.Any(genre => movie.Genre.Contains(genre)))
                {
                    MovieRepository.AddFilter(movie);
                }
            }
        }
        ViewBag.FilteredMovies = MovieRepository.filteredMovies;
        ViewBag.account = AccountRepository.profile;
        ViewBag.accountCount = AccountRepository.profile.Count;
        return View("MovieView", MovieRepository.movies);
    }

    [HttpGet]
    public IActionResult Account()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddMovie()
    {
        if (AccountRepository.profile.Count == 0)
        {
            TempData["AlertMessage"] = "You must sign in to access this page.";
        }
        Debug.WriteLine(AccountRepository.profile.Count);
        ViewBag.accountCount = AccountRepository.profile.Count;
        ViewBag.account = AccountRepository.profile;
        return View();
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie, string[] tags, string canvasImage)
    {
        // Count of accounts currently in the repository
        ViewBag.accountCount = AccountRepository.profile.Count;
        // Provides account data to the view
        ViewBag.account = AccountRepository.profile;

        // Check if there are no profiles in the repository, indicating no user is signed in
        if (AccountRepository.profile.Count == 0)
        {
            // Sets a temporary alert message indicating the need to sign in
            TempData["AlertMessage"] = "You must sign in to access this page.";
            // Returns the current view with the movie object
            return View(movie);
        }

        // Check if the model state is valid (all required fields are properly filled in)
        if (ModelState.IsValid)
        {
            // Assigns the tags from the form to the movie object
            movie.Tags = new List<string>(tags);
            // Adds the movie to the repository
            MovieRepository.AddMovie(movie);

            // Checks if canvas image data is provided
            if (!string.IsNullOrEmpty(canvasImage))
            {
                // Process to save the canvas image
                byte[] imageBytes = Convert.FromBase64String(canvasImage.Split(',')[1]);
                string folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                string fileName = $"{movie.Id}.png"; // Naming the file using the movie's ID
                string filePath = Path.Combine(folderPath, fileName);

                // If the images directory doesn't exist, create it
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Save the image bytes as a PNG file at the specified path
                System.IO.File.WriteAllBytes(filePath, imageBytes);
            }

            // Set a success message for the view
            ViewBag.success = "It worked ok?!";
            // Returns to a new view (presumably to add another movie or display a success message)
            return View();
        }
        else
        {
            // Set a failure message for the view
            ViewBag.success = "You did a bad thing";
            // Return to the current view with the movie object, indicating submission failure
            return View(movie);
        }
    }

    private void SaveImage(string imageBase64, string fileName)
    {
        // Convert the Base64 encoded string to byte array
        byte[] imageBytes = Convert.FromBase64String(imageBase64.Split(',')[1]);
        // Defines the folder path for storing images
        string folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images");
        // Combines the folder path and file name to create the full file path
        string filePath = Path.Combine(folderPath, fileName);

        // Creates the directory for storing images if it doesn't already exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Writes the byte array as an image file to the specified file path
        System.IO.File.WriteAllBytes(filePath, imageBytes);
    }

    [HttpGet]
    public IActionResult MovieID(int id)
    {
        if (AccountRepository.profile.Count == 0)
        {
            TempData["AlertMessage"] = "You must sign in to access this page.";
        }
        Debug.WriteLine(AccountRepository.profile.Count);
        ViewBag.account = AccountRepository.profile;
        ViewBag.accountCount = AccountRepository.profile.Count;
        var movie = MovieRepository.GetMovieById(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    public IActionResult Whoops()
    {
        return View();
    }
}
