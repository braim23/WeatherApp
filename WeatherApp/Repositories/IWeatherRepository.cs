using WeatherApp.OpenWeatherMapModel;

namespace WeatherApp.Repositories;

public interface IWeatherRepository
{
    WeatherResponse GetForecast(string city);
}
