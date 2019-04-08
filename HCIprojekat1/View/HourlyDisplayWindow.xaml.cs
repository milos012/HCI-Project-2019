using HCIprojekat1.Controllers;
using HCIprojekat1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCIprojekat1.View
{
    /// <summary>
    /// Interaction logic for HourlyDisplayWindow.xaml
    /// </summary>
    
    public partial class HourlyDisplayWindow : Window
    {
        static ForecastApp forecast;
        public HourlyDisplayWindow()
        {
            InitializeComponent();

            ForecastController fc = new ForecastController();
            HourlyDisplayData hh = fc.GetHourlyData();
            for (int i = 0; i < hh.GetDisplayHourCount(); i++)
            {
                HourlyDisplayData.HourData h = hh.GetNextHourInfo();
                switch (i)
                {
                    case 0:
                        _Time = h.Time;
                        Vreme1.DataContext = this;
                        _TemperatureInfo = h.Temperature;
                        Temperatura1.DataContext = this;
                        _Probability = h.Probability;
                        Verovatnoca1.DataContext = this;
                        break;
                    case 1:
                        _Time2 = h.Time;
                        Vreme2.DataContext = this;
                        _TemperatureInfo2 = h.Temperature;
                        Temperatura2.DataContext = this;
                        _Probability2 = h.Probability;
                        Verovatnoca2.DataContext = this;
                        break;
                    case 2:
                        _Time3 = h.Time;
                        Vreme3.DataContext = this;
                        _TemperatureInfo3 = h.Temperature;
                        Temperatura3.DataContext = this;
                        _Probability3 = h.Probability;
                        Verovatnoca3.DataContext = this;
                        break;
                    default:
                        break;
                }

            }
            
        }

        private string _Time;
        public string Time
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
            }
        }

        private string _TemperatureInfo;
        public string TemperatureInfo
        {
            get
            {
                return _TemperatureInfo;
            }
            set
            {
                _TemperatureInfo = value;
            }
        }

        private string _Probability;
        public string Probability
        {
            get
            {
                return _Probability;
            }
            set
            {
                _Probability = value;
            }
        }

        private string _Time2;
        public string Time2
        {
            get
            {
                return _Time2;
            }
            set
            {
                _Time2 = value;
            }
        }

        private string _TemperatureInfo2;
        public string TemperatureInfo2
        {
            get
            {
                return _TemperatureInfo2;
            }
            set
            {
                _TemperatureInfo2 = value;
            }
        }

        private string _Probability2;
        public string Probability2
        {
            get
            {
                return _Probability2;
            }
            set
            {
                _Probability2 = value;
            }
        }

        private string _Time3;
        public string Time3
        {
            get
            {
                return _Time3;
            }
            set
            {
                _Time3 = value;
            }
        }

        private string _TemperatureInfo3;
        public string TemperatureInfo3
        {
            get
            {
                return _TemperatureInfo3;
            }
            set
            {
                _TemperatureInfo3 = value;
            }
        }

        private string _Probability3;
        public string Probability3
        {
            get
            {
                return _Probability3;
            }
            set
            {
                _Probability3 = value;
            }
        }

    }
}
