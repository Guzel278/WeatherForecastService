using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;

using System.Threading.Tasks;
using WeatherForecastService.Models;

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

        public record Forecast(Weather[] weather, Main main, long dt, string name);
        public record Wind(decimal deg, decimal speed);
        public record WindWeather(Wind Wind, long dt, string name);





        public async Task<Forecast> GetCurrentWeatherAsync(string city)
        {
            return await httpClient.GetFromJsonAsync<Forecast>(
                $"https://{serviceSettings.OpenWeatherHost}/data/2.5/weather?q={city}&appid={serviceSettings.ApiKey}&units=metric");

        }

        public async Task<WindWeather> GetWindWeatherAsync(string city)
        {
            return await httpClient.GetFromJsonAsync <WindWeather>(
                $"https://{serviceSettings.OpenWeatherHost}/data/2.5/weather?q={city}&appid={serviceSettings.ApiKey}&units=metric");
        }
    

        public async Task<Forecast> GetFutureAsync(string city)
        {
           
          return await httpClient.GetFromJsonAsync<Forecast>(
                $"https://{serviceSettings.OpenWeatherHost}/data/2.5/forecast?q={city}&appid={serviceSettings.ApiKey}&units=metric");
            
        }
    }
}
