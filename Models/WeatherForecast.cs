using Microsoft.AspNetCore.Cors;
using System;

namespace PetWiki
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC *1.8);

        public string Summary { get; set; }
    }
}
