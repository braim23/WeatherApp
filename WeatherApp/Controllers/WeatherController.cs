using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WeatherApp.Models;
using WeatherApp.OpenWeatherMapModel;
using WeatherApp.Repositories;

namespace WeatherApp.Controllers;

public class WeatherController : Controller
{
    private readonly IWeatherRepository _weatherRepository;

    public WeatherController(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    [HttpGet]
    public IActionResult SearchByCity(string? city)
    {
        if(city != null)
        {
            WeatherResponse weatherResponse = _weatherRepository.GetForecast(city);
            City viewModel = new City();
            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Temperature = weatherResponse.Main.Temp;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;

            }
            return View(viewModel);
        }
        else
        {
            WeatherResponse weatherResponse = _weatherRepository.GetForecast("Mecca");
            City viewModel = new City();
            viewModel.Name = weatherResponse.Name;
            viewModel.Temperature = weatherResponse.Main.Temp;
            viewModel.Humidity = weatherResponse.Main.Humidity;
            viewModel.Pressure = weatherResponse.Main.Pressure;
            viewModel.Weather = weatherResponse.Weather[0].Main;
            viewModel.Wind = weatherResponse.Wind.Speed;
            return View(viewModel);
        }
        
    }
    [HttpPost]
    public IActionResult SearchByCity(SearchByCity model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("SearchByCity", "Weather", new { City = model.CityName });
        }
        else
        {
            return View(model);
        }
    }
    
}
