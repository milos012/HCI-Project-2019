using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat1.View
{
    class WeeklyDisplayData
    {
        // U objektima ove klase bice smesteni podaci o
        // o (<displayDayCount> - 1) danima nakon
        // zahtevanog dana.
        public class DayData
        {
            public string DateLabel { get; set; }
            public string Icon { get; set; }

            // Formatirani ispis temperature u formatu (<max_temp> °C / <min_temp> °C).
            public string Temperature { get; set; }


            public string Probability { get; set; }

            public DayData(string dateLabel, string icon, string temperature, string probability)
            {
                DateLabel = dateLabel;
                Icon = icon;
                Temperature = temperature;
                Probability = probability;
            }
        }

        // Broj dana koji ce se prikazati u "Weekly" tabu aplikacije.
        // Ukoliko se zeli dovuci manji ili veci broj dana iz weather
        // api-ja, neophodno je samo promeniti ovaj broj.
        private const int displayDayCount = 6;

        // Iterator indeks. Automatski pruza view delu aplikacije informacije
        // o danu sa pozicije <currentIndex>. Automatski se vraca na prvi element 
        // liste u slucaju prekoracenja.
        private int currentIndex = 0;

        // Lista koja sadrzi informacije o narednih <displayDayCount> dana u 
        // odnosu na trenutak kada je zahtevan request od weather api-ja.
        private List<DayData> displayDays;

        public int GetDisplayDayCount()
        {
            return displayDayCount;
        }

        public WeeklyDisplayData(WeatherAPI wAPI, IpData locationInfo)
        {
            // Iterira kroz data niz daily dela JSON response-a i 
            // prikuplja informacije za <displayDayCount> dan(a).
            foreach (DailyWeatherData iter in wAPI.daily.data)
            {
                string dayLabel = GenerateDayLabel(iter.time);
                displayDays.Add(new DayData(dayLabel, iter.icon, "" + iter.temperatureMax + "°C / " + iter.temperatureMin + "°C", "" + (iter.precipProbability * 100) + "%"));
            }
        }

        // Interna funkcija za generisanje formatiranog ispisa dana u nedelji
        // ("Monday, 8 April", "Tuesday, 9 April", itd).
        private string GenerateDayLabel(long dataTime)
        {
            var timeSpan = TimeSpan.FromSeconds(dataTime);
            var timeStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var localDateTime = timeStart.Add(timeSpan).ToLocalTime();

            var dayOfTheWeek = localDateTime.DayOfWeek.ToString();
            var day = localDateTime.Day.ToString();
            var month = localDateTime.Month.ToString();

            return dayOfTheWeek + ", " + day + month;
        }

        // Dohvata element iz liste sa lokacije <currentIndex>, uz
        // inkrementiranje vrednosti <currentIndex> promenljive.
        // U slucaju da je <currentIndex> vece od <displayDayCount>
        // vrednost currentIndex promenljive se postavlja na 0.
        public DayData GetNextDayInfo()
        {
            DayData dayToDisplay = displayDays.ElementAt(currentIndex++);
            if (currentIndex >= displayDayCount)
            {
                currentIndex = 0;
            }

            return dayToDisplay;
        }
    }
}