using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HW4Project.Models;
using System.Drawing;

namespace HW4Project.Controllers;

public class ColorInterpolationController : Controller
{
    [HttpGet]
    public IActionResult Interpolation()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Interpolation(ColorInterpolation c)
    {
        if (!ModelState.IsValid)
        {
            return View(c); // Return the view with validation errors
        }
        // convert hex to rgb
        // Check to see if setting these variables is necessary
        Color rgbFirstColor = ColorTranslator.FromHtml(c.Color1);
        Color rgbSecondColor = ColorTranslator.FromHtml(c.Color2);
#pragma warning disable CS8629 // Nullable value type may be null.
        int num = (int)c.NumOfColors;
#pragma warning restore CS8629 // Nullable value type may be null.

        // convert rgb to hsv
        double hue1, saturation1, value1;
        InterpolationMethod.ColorToHSV(rgbFirstColor, out hue1, out saturation1, out value1);

        double hue2, saturation2, value2;
        InterpolationMethod.ColorToHSV(rgbSecondColor, out hue2, out saturation2, out value2);

        // calc to determine increment val(last value - first value / numberofcolors)
        double hIncrement;
        InterpolationMethod.Increment(hue1, hue2, num, out hIncrement);

        double sIncrement;
        InterpolationMethod.Increment(saturation1, saturation2, num, out sIncrement);

        double vIncrement;
        InterpolationMethod.Increment(value1, value2, num, out vIncrement);

        // Create list
        c.newColor.Add(c.Color1); // First Color

        // Loop through hsv values for num times
        for (int i = num; i > 0; i--) 
        {   
            //check which user input is greater and either add or subtract increment from the first
            if (hue1 < hue2)
            {hue1 += hIncrement;}
            else
            {hue1 -= hIncrement;}
            Debug.WriteLine($"hue is: {hue1}");

            if (saturation1 < saturation2)
            {saturation1 += sIncrement;}
            else{saturation1 -= sIncrement;}
            Debug.WriteLine($"saturation is: {saturation1}");

            if (value1 < value2)
            {value1 += vIncrement;}
            else 
            {value1 -= vIncrement;}
            Debug.WriteLine($"value is: {value1}");

            // Convert to RGB
            Color newColorValue = InterpolationMethod.ColorFromHSV(hue1, saturation1, value1);
            // Convert to hex
            string hex = $"#{newColorValue.R:X2}{newColorValue.G:X2}{newColorValue.B:X2}";
            c.newColor.Add(hex); // Add to list
        }

        c.newColor.Add(c.Color2); // Second Color
        return View("Interpolation", c); // Return list to view
    }
}