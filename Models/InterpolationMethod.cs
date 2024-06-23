using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace HW4Project.Models;

public static class InterpolationMethod
{
    public static void Increment(double val1, double val2, int num, out double Increment)
    {
        if (val2 > val1)
        {
            Increment = (val2 - val1)/(num+1);
        }
        else
        {
            Increment = (val1 - val2)/(num+1);           
        }
    }

    public static Color ColorFromHSV(double hue, double saturation, double value)
    {
        int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
        double f = hue / 60 - Math.Floor(hue / 60);

        value = value * 255;
        int v = Convert.ToInt32((value*.01));
        int p = Convert.ToInt32((value*.01)* (1 - (saturation*.01)));
        int q = Convert.ToInt32((value*.01)* (1 - f * (saturation*.01)));
        int t = Convert.ToInt32((value*.01) * (1 - (1 - f) * (saturation*.01)));

        if (hi == 0)
            return Color.FromArgb(255, v, t, p);
        else if (hi == 1)
            return Color.FromArgb(255, q, v, p);
        else if (hi == 2)
            return Color.FromArgb(255, p, v, t);
        else if (hi == 3)
            return Color.FromArgb(255, p, q, v);
        else if (hi == 4)
            return Color.FromArgb(255, t, p, v);
        else
            return Color.FromArgb(255, v, p, q);
    }
    // convert rgb to hsv
    public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
    {
        int max = Math.Max(color.R, Math.Max(color.G, color.B));
        int min = Math.Min(color.R, Math.Min(color.G, color.B));

        hue = Math.Round(color.GetHue());
        saturation = Math.Round((((max == 0) ? 0 : 1d - (1d * min / max))*100), 1);
        value = Math.Round(((max / 255d)*100), 1);
    }

    internal static void Increment(double hue1, double hue2, int? numOfColors, out double hIncrement)
    {
        throw new NotImplementedException();
    }
}