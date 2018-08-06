using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace D3WeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string key = "6ad26b6b9f171f1145983e3951776362";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
            + zipCode + ",us&appid=" + key + "&units=imperial";

            try
            {
                 dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
           
                if (results["weather"] != null)
                {
                    Weather weather = new Weather();
                    weather.Title = (string)results["name"];
                    weather.Temperature = (string)results["main"]["temp"] + " F";
                    weather.Wind = (string)results["wind"]["speed"] + " mph";
                    weather.Humidity = (string)results["main"]["humidity"] + " %";                    
                    weather.visibility = (string)results["weather"][0]["main"];
                    DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                    DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                    DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                    weather.Sunrise = sunrise.ToString() + " UTC";
                    weather.Sunset = sunset.ToString() + " UTC";
                    return weather;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
