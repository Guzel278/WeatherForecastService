using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastService.Models
{
    public class FutureWeather
    {
       
            [JsonProperty("cod")]
            public string Cod { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("cnt")]
            public string Cnt { get; set; }

            [JsonProperty("list")]
            public List<FutureEntity> FutureEntity { get; set; }
    }
    public class FutureEntity
    {
        [JsonProperty("dt")]
        public string Dt { get; set; }

        [JsonProperty("main")]
        public MainTemp mainTemp { get; set; }      
        
        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("pop")]
        public string Pop { get; set; }

        [JsonProperty("dt_txt")]
        public string Date { get; set; }
    }
    public class MainTemp
    {
        [JsonProperty("temp")]
        public string Temp { get; set; }

        [JsonProperty("feels_like")]
        public string Feels_like { get; set; }

        [JsonProperty("temp_min")]
        public string Temp_min { get; set; }

        [JsonProperty("temp_max")]
        public string Temp_max { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("sea_level")]
        public string Sea_level { get; set; }

        [JsonProperty("grnd_level")]
        public string Grnd_level { get; set; }

        [JsonProperty("temp_kf")]
        public string Temp_kf { get; set; }

    }
}
