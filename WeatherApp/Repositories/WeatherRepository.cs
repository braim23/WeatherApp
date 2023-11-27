using WeatherApp.OpenWeatherMapModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
namespace WeatherApp.Repositories;

public class WeatherRepository : IWeatherRepository
{
    public WeatherResponse GetForecast(string city)
    {
        string APP_ID = Configuration.SD.OPEN_WEATHER_APP_ID;
        var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={APP_ID}");

        var x = "";
        var request = new RestRequest(x, Method.Get);
        var response = client.Execute(request);
        if(response.IsSuccessful)
        {
            var content = JsonConvert.DeserializeObject<JToken>(response.Content);
            return content?.ToObject<WeatherResponse>();
        }
        else
        {
            return null;
        }
    }
}
