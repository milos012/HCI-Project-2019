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
        ForecastApp forecastAppInstance;
        WeatherAPI weatherAPI;
        IpData locationInfo;
        public ForecastController()
        {
            // Dohvatanje forecastApp instance.
            forecastAppInstance = ForecastApp.GetInstance();

            // Weather info.
            weatherAPI = forecastAppInstance.WeatherDataFromJSON();

            // City info.
            locationInfo = forecastAppInstance.IpAPIData;
            
        }

        // Metoda koja izvlaci jedino neophodne podatke za prikazivanje trenutne prognoze.
        public CurrentlyDisplayData GetCurrentData()
        {

            return new CurrentlyDisplayData(
                locationInfo.city + ", " + locationInfo.country,
                DateTime.Now.ToString(),
                weatherAPI.currently.icon,
                weatherAPI.currently.temperature + "°C (feels like " + weatherAPI.currently.apparentTemperature + "°C)",
                weatherAPI.currently.summary,
                weatherAPI.currently.precipProbability != 0 ? "Precipitation probability: " + weatherAPI.currently.precipProbability * 100 + "%": "No probability of precipitation."
                );
        }

        public HourlyDisplayData GetHourlyData()
        {
            // Konstruktor HourlyDisplayData klase interno kreira listu
            // sa neophodnim informacijama u odgovarajucem formatu.
            return new HourlyDisplayData(weatherAPI, locationInfo); 
        }

        public WeeklyDisplayData GetWeeklyData()
        {
            // Konstruktor WeeklyDisplayData klase interno kreira listu
            // sa neophodnim informacijama u odgovarajucem formatu.
            return new WeeklyDisplayData(weatherAPI, locationInfo);
        }

        // Metoda koja azurira trenutno posmatrani grad.
        // Nakon ove metode OBAVEZNO osveziti CurrentDisplayData
        // objekat pozivom metode GetCurrentData().

        public void ChangeToCity(string city)
        {
            forecastAppInstance.ChangeToCity(city);
            weatherAPI = forecastAppInstance.AllForecastData;
            locationInfo.city = city;
        }
    }
}
