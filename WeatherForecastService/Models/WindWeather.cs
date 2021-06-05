using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities.Models
{
    public class WindWeather
    {
        public string City { get; set; }
        public DateTime Date { get; set; }
        public int Speed { get; set; }
        public string Direction { get; set; }
    }
}
