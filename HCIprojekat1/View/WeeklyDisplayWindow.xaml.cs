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
    /// Interaction logic for WeeklyDisplayWindow.xaml
    /// </summary>
    public partial class WeeklyDisplayWindow : Window
    {
        public WeeklyDisplayWindow()
        {
            InitializeComponent();

            ForecastController fc = new ForecastController();
            WeeklyDisplayData wdd = fc.GetWeeklyData();
            for (int i = 0; i < wdd.GetDisplayDayCount(); i++)
            {
                //Console.WriteLine(i);
                WeeklyDisplayData.DayData d = wdd.GetNextDayInfo();
                switch (i)
                {
                    case 0:
                        _Date = d.DateLabel;
                        DanasnjiDatum1.DataContext = this;
                        _TemperatureInfo = d.Temperature;
                        Temperatura1.DataContext = this;
                        _Probability = d.Probability;
                        Verovatnoca1.DataContext = this;
                        break;
                    case 1:
                        _Date2 = d.DateLabel;
                        DanasnjiDatum2.DataContext = this;
                        _TemperatureInfo2 = d.Temperature;
                        Temperatura2.DataContext = this;
                        _Probability2 = d.Probability;
                        Verovatnoca2.DataContext = this;
                        break;
                    case 2:
                        _Date3 = d.DateLabel;
                        DanasnjiDatum3.DataContext = this;
                        _TemperatureInfo3 = d.Temperature;
                        Temperatura3.DataContext = this;
                        _Probability3 = d.Probability;
                        Verovatnoca3.DataContext = this;
                        break;
                    case 3:
                        _Date4 = d.DateLabel;
                        DanasnjiDatum4.DataContext = this;
                        _TemperatureInfo4 = d.Temperature;
                        Temperatura4.DataContext = this;
                        _Probability4 = d.Probability;
                        Verovatnoca4.DataContext = this;
                        break;
                    case 4:
                        _Date5 = d.DateLabel;
                        DanasnjiDatum5.DataContext = this;
                        _TemperatureInfo5 = d.Temperature;
                        Temperatura5.DataContext = this;
                        _Probability5 = d.Probability;
                        Verovatnoca5.DataContext = this;
                        break;
                    case 5:
                        _Date6 = d.DateLabel;
                        DanasnjiDatum6.DataContext = this;
                        _TemperatureInfo6 = d.Temperature;
                        Temperatura6.DataContext = this;
                        _Probability6 = d.Probability;
                        Verovatnoca6.DataContext = this;
                        break;
                    case 6:
                        _Date7 = d.DateLabel;
                        DanasnjiDatum7.DataContext = this;
                        _TemperatureInfo7 = d.Temperature;
                        Temperatura7.DataContext = this;
                        _Probability7 = d.Probability;
                        Verovatnoca7.DataContext = this;
                        break;
                    default:
                        break;

                }
                
                
            }
        }

        private string _Date;
        public string Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
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

        private string _Date2;
        public string Date2
        {
            get
            {
                return _Date2;
            }
            set
            {
                _Date2 = value;
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

        private string _Date3;
        public string Date3
        {
            get
            {
                return _Date3;
            }
            set
            {
                _Date3 = value;
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

        private string _Date4;
        public string Date4
        {
            get
            {
                return _Date4;
            }
            set
            {
                _Date4 = value;
            }
        }

        private string _TemperatureInfo4;
        public string TemperatureInfo4
        {
            get
            {
                return _TemperatureInfo4;
            }
            set
            {
                _TemperatureInfo4 = value;
            }
        }

        private string _Probability4;
        public string Probability4
        {
            get
            {
                return _Probability4;
            }
            set
            {
                _Probability4 = value;
            }
        }

        private string _Date5;
        public string Date5
        {
            get
            {
                return _Date5;
            }
            set
            {
                _Date5 = value;
            }
        }

        private string _TemperatureInfo5;
        public string TemperatureInfo5
        {
            get
            {
                return _TemperatureInfo5;
            }
            set
            {
                _TemperatureInfo5 = value;
            }
        }

        private string _Probability5;
        public string Probability5
        {
            get
            {
                return _Probability5;
            }
            set
            {
                _Probability5 = value;
            }
        }

        private string _Date6;
        public string Date6
        {
            get
            {
                return _Date6;
            }
            set
            {
                _Date6 = value;
            }
        }

        private string _TemperatureInfo6;
        public string TemperatureInfo6
        {
            get
            {
                return _TemperatureInfo6;
            }
            set
            {
                _TemperatureInfo6 = value;
            }
        }

        private string _Probability6;
        public string Probability6
        {
            get
            {
                return _Probability6;
            }
            set
            {
                _Probability6 = value;
            }
        }

        private string _Date7;
        public string Date7
        {
            get
            {
                return _Date7;
            }
            set
            {
                _Date7 = value;
            }
        }

        private string _TemperatureInfo7;
        public string TemperatureInfo7
        {
            get
            {
                return _TemperatureInfo7;
            }
            set
            {
                _TemperatureInfo7 = value;
            }
        }

        private string _Probability7;
        public string Probability7
        {
            get
            {
                return _Probability7;
            }
            set
            {
                _Probability7 = value;
            }
        }
    }
}
