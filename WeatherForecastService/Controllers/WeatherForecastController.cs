using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weather.Entities.Models;
using WeatherForecastService;
using WeatherForecastService.Models;

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
        [Route("Weather/{city}")]
        public async Task<WeatherForecast> Get(string city)
        {
            var forecast = await weatherClient.GetCurrentWeatherAsync(city);

            return new WeatherForecast
            {
                City = forecast.name,
                Summary = forecast.weather[0].description,
                TemperatureC = (int)forecast.main.temp,
                Date = DateTimeOffset.FromUnixTimeSeconds(forecast.dt).DateTime
            };
        }

    
        [HttpGet]
        [Route("Wind/{city}")]
        public async Task<WindWeather> GetForecast(string city)
        {
            var wind = await weatherClient.GetWindWeatherAsync(city);

            return new WindWeather
            {   
                City = wind.name,
                Direction = Helper.Direction(wind.Wind.deg),
                Speed = wind.Wind.speed,
                Date = DateTimeOffset.FromUnixTimeSeconds(wind.dt).DateTime
            };
        }

        [HttpGet]
        [Route("Future/{city}")]
        public async Task<WeatherForecast> GetFuture(string city)
        {

            var future = await weatherClient.GetFutureAsync(city);
            var weatherFiveDaysModel = new FutureWeather
            {
                WeatherFiveDays = new List<WeatherForecast>()
            };
            return new WeatherForecast
                {
                Summary = future.weather[0].description,
                TemperatureC = (int)future.main.temp,
                Date = DateTimeOffset.FromUnixTimeSeconds(future.dt).DateTime
            };
        }
    }
}
