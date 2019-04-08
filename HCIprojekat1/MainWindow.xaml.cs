using HCIprojekat1.Controllers;
using HCIprojekat1.View;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using System.ComponentModel;
namespace HCIprojekat1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //static ForecastApp forecast;
        static ForecastController fc;
        
        public MainWindow()
        {
            InitializeComponent();

            fc = new ForecastController();


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

            HourlyDisplayData hh = fc.GetHourlyData();
            for (int i = 0; i < hh.GetDisplayHourCount(); i++)
            {
                HourlyDisplayData.HourData h = hh.GetNextHourInfo();
                switch (i)
                {
                    case 0:
                        _Time11 = h.Time;
                        Vreme11.DataContext = this;
                        _TemperatureInfo11 = h.Temperature;
                        Temperatura11.DataContext = this;
                        _Probability11 = h.Probability;
                        Verovatnoca11.DataContext = this;
                        break;
                    case 1:
                        _Time22 = h.Time;
                        Vreme22.DataContext = this;
                        _TemperatureInfo22 = h.Temperature;
                        Temperatura22.DataContext = this;
                        _Probability22 = h.Probability;
                        Verovatnoca22.DataContext = this;
                        break;
                    case 2:
                        _Time33 = h.Time;
                        Vreme33.DataContext = this;
                        _TemperatureInfo33 = h.Temperature;
                        Temperatura33.DataContext = this;
                        _Probability33 = h.Probability;
                        Verovatnoca33.DataContext = this;
                        break;
                    default:
                        break;
                }

            }
            //WeeklyDisplayData wdd = fc.GetWeeklyData();
            //HourlyDisplayData hdd = fc.GetHourlyData();
            //for (int i = 0; i <= 5;i++)
            //{
            //    WeeklyDisplayData.DayData day = wdd.GetNextDayInfo();
            //    StackPanel sp = new StackPanel { Orientation = Orientation.Horizontal };
            //    TextBox tb = new TextBox { Name = "TemperatureWeekDay" + i, MinHeight = 100, MinWidth = 100 };
            //    TextBox tb1 = new TextBox { Name = "ProbabilityWeekDay" + i, MinHeight = 100, MinWidth = 100 };
            //    TextBox tb2 = new TextBox { Name = "ProbabilityWeekDay" + i, MinHeight = 100, MinWidth = 100 };
            //    Image ikonica = new Image { Name = "Ikonica" + i};
            //    tb.Text = day.Temperature;
            //    tb1.Text = day.Probability;
            //    tb2.Text = day.DateLabel;
            //    sp.Children.Add(tb);
            //    sp.Children.Add(tb1);
            //    sp.Children.Add(tb2);
            //    tab3.Children.Add(sp);
            //}

            //for (int i = 0; i <= 2; i++)
            //{
            //    HourlyDisplayData.HourData hour = hdd.GetNextHourInfo();
            //    StackPanel sp = new StackPanel { Orientation = Orientation.Horizontal };
            //    TextBox tb = new TextBox { Name = "TemperatureHour" + i, MinHeight = 100, MinWidth = 100 };
            //    TextBox tb1 = new TextBox { Name = "ProbabilityHour" + i, MinHeight = 100, MinWidth = 100 };
            //    TextBox tb2 = new TextBox { Name = "TimeHour" + i, MinHeight = 100, MinWidth=100};
            //    Image ikonica = new Image { Name = "Ikonica" + i };
            //    tb.Text = hour.Time;
            //    tb1.Text = hour.Temperature;
            //    tb2.Text = hour.Probability;

            //    sp.Children.Add(tb);
            //    sp.Children.Add(tb1);
            //    sp.Children.Add(tb2);
            //    sp.Children.Add(ikonica);
            //    tab2.Children.Add(sp);
            //}

            RefreshData();
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
                OnPropertyChanged("TemperatureInfo");
            }
        }

        private string _Location;
        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
                OnPropertyChanged("Location");
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
                OnPropertyChanged("Date");
            }
        }

        // TODO: treba da se nadju ikonice na netu i ovaj Source da se izmeni da prikaze putanju do slike.
        private string _Source;
        public string Source
        {
            get
            {
                return _Source;
            }

            set
            {
                _Source = value;
                OnPropertyChanged("TemperatureInfo");
            }
        }

        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
                OnPropertyChanged("Message");
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
                OnPropertyChanged("Probability1");
            }
        }

        private string _Date1;
        public string Date1
        {
            get
            {
                return _Date1;
            }
            set
            {
                _Date1 = value;
            }
        }

        private string _TemperatureInfo1;
        public string TemperatureInfo1
        {
            get
            {
                return _TemperatureInfo1;
            }
            set
            {
                _TemperatureInfo1 = value;
            }
        }

        private string _Probability1;
        public string Probability1
        {
            get
            {
                return _Probability1;
            }
            set
            {
                _Probability1 = value;
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

        private string _Time11;
        public string Time1
        {
            get
            {
                return _Time11;
            }
            set
            {
                _Time11 = value;
            }
        }

        private string _TemperatureInfo11;
        public string TemperatureInfo11
        {
            get
            {
                return _TemperatureInfo11;
            }
            set
            {
                _TemperatureInfo11 = value;
            }
        }

        private string _Probability11;
        public string Probability11
        {
            get
            {
                return _Probability11;
            }
            set
            {
                _Probability11 = value;
            }
        }

        private string _Time22;
        public string Time22
        {
            get
            {
                return _Time22;
            }
            set
            {
                _Time22 = value;
            }
        }

        private string _TemperatureInfo22;
        public string TemperatureInfo22
        {
            get
            {
                return _TemperatureInfo22;
            }
            set
            {
                _TemperatureInfo22 = value;
            }
        }

        private string _Probability22;
        public string Probability22
        {
            get
            {
                return _Probability22;
            }
            set
            {
                _Probability22 = value;
            }
        }

        private string _Time33;
        public string Time33
        {
            get
            {
                return _Time33;
            }
            set
            {
                _Time33 = value;
            }
        }

        private string _TemperatureInfo33;
        public string TemperatureInfo33
        {
            get
            {
                return _TemperatureInfo33;
            }
            set
            {
                _TemperatureInfo33 = value;
            }
        }

        private string _Probability33;
        public string Probability33
        {
            get
            {
                return _Probability33;
            }
            set
            {
                _Probability33 = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private void RefreshData()
        {
            CurrentlyDisplayData c = fc.GetCurrentData();

            TemperatureInfo = c.TemperatureInfo;
            Temperatura.DataContext = this;
            Location = c.Location;
            Lokacija.DataContext = this;
            Date = c.Date;
            Datum.DataContext = this;

            Source = c.Icon;
            Ikonica.DataContext = this;

            Message = c.Message;
            Poruka.DataContext = this;
            Probability = c.Probability;
            Verovatnoca.DataContext = this;
        }

        private void ChangeCityButtonClick(object sender, RoutedEventArgs e)
        {
           
            fc.ChangeToCity(txtLocationInput.Text);

            RefreshData();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var w = new View.HourlyDisplayWindow();
            w.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var w = new View.WeeklyDisplayWindow();
            w.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}
