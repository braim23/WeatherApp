using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models;

public class SearchByCity
{
    [Required(ErrorMessage ="City name is empty!")]
    [Display(Name = "City name")]
    [StringLength(20, MinimumLength =2 , ErrorMessage ="Invalid city name, length must be between 2-20 chharacters!")]
    public string CityName { get; set; }
}
