using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers;

public class SearchController : Controller
{

    [HttpGet]
    public IActionResult Results(string searchString)
    {
        if (AccountRepository.profile.Count == 0)
        {
            TempData["AlertMessage"] = "You must sign in to access this page.";
        }
        ViewBag.account = AccountRepository.profile;
        ViewBag.accountCount = AccountRepository.profile.Count;
        // Clear results list
        MovieRepository.moviesResults.Clear();

        if (string.IsNullOrEmpty(searchString))
        {
            return View(MovieRepository.moviesResults);
        }

        foreach (var movie in MovieRepository.movies)
        {
            // Ensure movie and its properties are not null before accessing them
            if (movie != null)
            {
                bool isMatch = (!string.IsNullOrEmpty(movie.Title) && movie.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    || (!string.IsNullOrEmpty(movie.Genre) && movie.Genre.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    || (!string.IsNullOrEmpty(movie.Director) && movie.Director.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    || (!string.IsNullOrEmpty(movie.Synopsis) && movie.Synopsis.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    || (movie.Tags != null && movie.Tags.Any(tag => !string.IsNullOrEmpty(tag) && tag.Contains(searchString, StringComparison.OrdinalIgnoreCase)));

                if (isMatch)
                {
                    // Add to list if bool is true
                    MovieRepository.moviesResults.Add(movie);
                }
            }
        }

        return View(MovieRepository.moviesResults);
    }

    [HttpGet]
    public IActionResult MovieID(int id)
    {
        if (AccountRepository.profile.Count == 0)
        {
            TempData["AlertMessage"] = "You must sign in to access this page.";
        }
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