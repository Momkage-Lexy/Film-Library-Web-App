using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace HW4Project.Models;

public class ColorInterpolation
{
    public string Color1 { get; set; }

    public string Color2 { get; set; }

    [Required(ErrorMessage = "MISSING 'Number' FIELD")]
    public int? NumOfColors { get; set; }

    public List<string> newColor = new List<string>();
    public ColorInterpolation()
    {
        // Initialize the list in the constructor to avoid null reference exceptions
        newColor = new List<string>();
    }
    
    public override string ToString()
    {
        return $"{Color1}, {Color2}, {NumOfColors}";
    }
}
