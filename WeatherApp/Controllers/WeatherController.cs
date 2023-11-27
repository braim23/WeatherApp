using Microsoft.AspNetCore.Mvc;
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
    public IActionResult SearchByCity()
    {
        var viewModel = new SearchByCity();
        return View(viewModel);
    }
    [HttpPost]
    public IActionResult SearchByCity(SearchByCity model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("City", "Weather", new { City = model.CityName });
        }
        else
        {
            return View(model);
        }
    }
    [HttpGet]
    public IActionResult City(string city)
    {
        WeatherResponse weatherResponse = _weatherRepository.GetForecast(city);
        City viewModel = new City();
        if(weatherResponse != null)
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
}
