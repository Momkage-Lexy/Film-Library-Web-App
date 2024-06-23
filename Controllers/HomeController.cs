using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HW4Project.Models;
using System.Drawing;

namespace HW4Project.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    
    [HttpGet]
    public IActionResult RGBColor(int red, int green, int blue)
    {
        string hex = $"#{red:X2}{green:X2}{blue:X2}";
        ViewBag.hex = hex;
        return View();
    }

}
