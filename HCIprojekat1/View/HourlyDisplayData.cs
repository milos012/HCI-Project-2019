using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat1.View
{
    class HourlyDisplayData
    {

        // U objektima ove klase bice smesteni podaci o
        // zahtevanom satu i o (<displayHourCount> - 1) 
        // sata nakon zahtevanog sata.
        public class HourData {
            public string Time { get; set; }
            public string Icon { get; set; }

            public string Temperature { get; set; }

            public string Probability { get; set; }

            public HourData(string time, string icon, string temperature, string probability)
            {
                Time = time;
                Icon = icon;
                Temperature = temperature;
                Probability = probability;
            }

        }
        
        // Broj sati koji ce se prikazati u "Hourly" tabu aplikacije.
        // Ukoliko se zeli dovuci manji ili veci broj sati iz weather
        // api-ja, neophodno je samo promeniti ovaj broj.
        private const int displayHourCount = 3;

        // Iterator indeks. Automatski pruza view delu aplikacije informacije
        // o satu sa pozicije <currentIndex>. Automatski se vraca na prvi element 
        // liste u slucaju prekoracenja.
        private int currentIndex = 0;

        // Lista koja sadrzi informacije o narednih <displayHourCount> sati 
        // u odnosu na trenutak kada je zahtevan request od weather api-ja.
        private List<HourData> displayHours;

        public int GetDisplayHourCount()
        {
            return displayHourCount;
        }

        public HourlyDisplayData(WeatherAPI wAPI, IpData locationInfo) 
        {
            // Iterira kroz data niz hourly dela JSON response-a i 
            // prikuplja informacije za <displayHourCount> sat(a).
            foreach (CurrentWeatherData iter in wAPI.hourly.data)
            {
                string hourLabel = GenerateHourLabel(iter.time);
                displayHours.Add(new HourData(hourLabel, iter.icon, iter.temperature, "" + (iter.precipProbability * 100) + "%"));
            }
        }


        // Interna funkcija za generisanje formatiranog ispisa sata (15:00, 16:00, itd).
        private string GenerateHourLabel(int dataTime)
        {
            var timeSpan = TimeSpan.FromSeconds(dataTime);
            var timeStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var localDateTime = timeStart.Add(timeSpan).ToLocalTime();

            return localDateTime.Hour.ToString() + ":00";
        }

        // Dohvata element iz liste sa lokacije <currentIndex>, uz
        // inkrementiranje vrednosti <currentIndex> promenljive.
        // U slucaju da je <currentIndex> vece od <displayHourCount>
        // vrednost currentIndex promenljive se postavlja na 0.
        public HourData GetNextHourInfo()
        {
            HourData hourToDisplay = displayHours.ElementAt(currentIndex++);
            if (currentIndex >= displayHourCount)
            {
                currentIndex = 0;
            }

            return hourToDisplay;
        }

    }
}
