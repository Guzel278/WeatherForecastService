using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
    

        public async Task<FutureModel> GetFutureAsync(string city)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"https://{serviceSettings.OpenWeatherHost}/data/2.5/forecast?q={city}&appid={serviceSettings.ApiKey}&units=metric");
            var contect = await response.Content.ReadAsStringAsync();
            var futures = JsonConvert.DeserializeObject<FutureWeather>(contect);
            FutureModel futureModel = new FutureModel();
            futureModel.FutureEntityModel  = new List<FutureEntityModel>();
            foreach (var item in futures.FutureEntity)
            {
                FutureEntityModel futureEntityModel = new FutureEntityModel
                {
                   City = city,
                   Date = item.Date,
                   TemperatureC = item.mainTemp.Temp
                };
                futureModel.FutureEntityModel.Add(futureEntityModel);
            }
            //var forecast =  await httpClient.GetFromJsonAsync<Forecast>(
            //    $"https://{serviceSettings.OpenWeatherHost}/data/2.5/forecast?q={city}&appid={serviceSettings.ApiKey}&units=metric");
            return futureModel;
        }
    }
}
