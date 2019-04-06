using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat1.View
{
    class CurrentlyDisplayData
    {
        public string Location { get; set; }
        public string Date { get; set; }
        public string Icon { get; set; }

        public string TemperatureInfo { get; set; }

        public string Message { get; set; }
        public string Probability { get; set; }

        public CurrentlyDisplayData(string location, string date, string icon, string temperatureInfo, string message, string probability)
        {
            Location = location;
            Date = date;
            Icon = icon;
            TemperatureInfo = temperatureInfo;
            Message = message;
            Probability = probability;
        }
    }
}
