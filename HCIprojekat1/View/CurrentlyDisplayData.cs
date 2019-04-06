using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat1.View
{
    class CurrentlyDisplayData
    {
        string Location { get; set; }
        string Date { get; set; }
        string Icon { get; set; } 

        string TemperatureInfo { get; set; }

        string Message { get; set; }
        string Probability { get; set; }

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
