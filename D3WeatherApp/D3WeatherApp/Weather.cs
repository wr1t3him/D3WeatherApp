using System;
using System.Collections.Generic;
using System.Text;

namespace D3WeatherApp
{
    public class Weather
    {
        public string Title { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Humidity { get; set; }
        public string visibility { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }

        public Weather()
        {
            this.Title = "";
            this.Temperature = "";
            this.Wind = "";
            this.Humidity = "";
            this.visibility = "";
            this.Sunrise = "";
            this.Sunset = "";

        }
    }
}
