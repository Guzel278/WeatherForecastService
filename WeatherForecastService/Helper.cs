using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastService
{
    public class Helper
    {
        public static string Direction(decimal degree)
        {
          
            string[] caridnals = {
                "North (N)",
                "NorthNorthEast (NNE)",
                "NorthEast (NE)",
                "EastNorthEast (ENE)",
                "East (E)",
                "EastSouthEast (ESE)",
                "SouthEast (SE)",
                "SouthSouthEast (SSE)",
                "South (S)",
                "SouthSouthWest (SSW)",
                "SouthWest (SW)",
                "WestSouthWest (WSW)",
                "West (W)",
                "WestNorthWest (WNW)",
                "NorthWest (NW)",
                "NorthNorthWest (NNW)",
                "North (N)" };

            return caridnals[(int)Math.Round(((double)degree * 10 % 3600) / 225)];

        }
    }
}
