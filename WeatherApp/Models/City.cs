using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models;

public class City
{

    [Required(ErrorMessage = "City name is empty!")]
    [Display(Name = "City name")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid city name, length must be between 2-20 characters!")]
    public string CityName { get; set; }

    [Display(Name = "City name:")]
    public string Name { get; set; }
    [Display(Name = "Temp. C°")]
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
