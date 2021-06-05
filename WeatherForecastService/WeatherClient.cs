using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WeatherForecastService
{
    public class WeatherClient
    {
        private readonly HttpClient httpClient;
        private readonly ServiceSettings serviceSettings;

        public WeatherClient(HttpClient httpClient, IOptions<ServiceSettings> options)
        {
            this.httpClient = httpClient;
            serviceSettings = options.Value;
        }

        public record Weather(string description);

        public record Main(decimal temp);

        public record Forecast(Weather[] weather, Main main, long dt);

        public record Speed(int speed);
        public record Direction(string direction);
        public record Wind(Speed speed, Direction direction, long dt);

        public async Task<Forecast> GetCurrentWeatherAsync(string city)
        {
            var forecast = await httpClient.GetFromJsonAsync<Forecast>(
                $"https://{serviceSettings.OpenWeatherHost}/data/2.5/weather?q={city}&appid={serviceSettings.ApiKey}&units=metric");

            return forecast;
        }

        public async Task<Wind> GetWindWeatherAsync(string city)
        {
            var wind = await httpClient.GetFromJsonAsync<Wind>(
                $"https://{serviceSettings.OpenWeatherHost}/data/2.5/weather?q={city}&appid={serviceSettings.ApiKey}&units=metric");

            return wind;
        }
    }
}
