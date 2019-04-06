using HCIprojekat1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat1.Controllers
{
    class ForecastController
    {

        // Metoda koja izvlaci jedino neophodne podatke za prikazivanje trenutne prognoze.
        public CurrentlyDisplayData GetCurrentData()
        {
            ForecastApp forecastApp = ForecastApp.GetInstance();
            
            // Weather info.
            WeatherAPI wAPI = forecastApp.WeatherDataFromJSON();

            // City info.
            IpData locationInfo = forecastApp.IpAPIData;

            return new CurrentlyDisplayData (
                locationInfo.city + ", " + locationInfo.country,
                DateTime.Now.ToString(),
                wAPI.currently.icon,
                wAPI.currently.temperature + "` (feels like " + wAPI.currently.apparentTemperature + "`)",
                wAPI.currently.summary,
                wAPI.currently.precipProbability != 0 ? "Precipitation probability: " + wAPI.currently.precipProbability : "No probability of precipitation."
                );
        }
    }
}
