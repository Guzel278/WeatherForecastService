using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weather.Entities.Models;
using WeatherForecastService;

namespace WeatherForecastService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherClient weatherClient;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            WeatherClient weatherClient)
        {
            _logger = logger;
            this.weatherClient = weatherClient;
        }

        [HttpGet]
        [Route("{city}")]
        public async Task<WeatherForecast> Get(string city)
        {
            var forecast = await weatherClient.GetCurrentWeatherAsync(city);

            return new WeatherForecast
            {
                Summary = forecast.weather[0].description,
                TemperatureC = (int)forecast.main.temp,
                Date = DateTimeOffset.FromUnixTimeSeconds(forecast.dt).DateTime
            };
        }

        [HttpGet]
        [Route("{city}")]
        public async Task<WindWeather> GetWind(string city)
        {
              var forecast = await weatherClient.GetWindWeatherAsync(city);

                return new WindWeather
                {
                    Speed = forecast.speed.speed,
                    Direction = forecast.direction.direction,
                    Date = DateTimeOffset.FromUnixTimeSeconds(forecast.dt).DateTime
                };
         
        }
    }
}
