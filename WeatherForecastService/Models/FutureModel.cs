using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastService.Models
{
    public class FutureModel
    {
        public List<FutureEntityModel> FutureEntityModel { get; set; }
    }
    public class FutureEntityModel
    {
        public string City { get; set; }
        public string Date { get; set; }
        public string TemperatureC { get; set; }
       
    }
}
