using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models;

public class City
{
    [Display(Name = "City name:")]
    public string Name { get; set; }
    [Display(Name = "Temp.")]
    public float Temperature { get; set; }

    [Display(Name = "Humidity")]
    public int Humidity { get; set; }
    [Display(Name = "Pressure")]
    public int Pressure { get; set; }
    [Display(Name = "Wind speed:")]
    public float Wind { get; set; }
    [Display(Name = "Weather condition:")]
    public string Weather { get; set; }
}
