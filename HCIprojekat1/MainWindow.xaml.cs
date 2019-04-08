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
            HourlyDisplayData hdd = fc.GetHourlyData();
            for (int i = 0; i <= 5;i++)
            {
                WeeklyDisplayData.DayData day = wdd.GetNextDayInfo();
                StackPanel sp = new StackPanel { Orientation = Orientation.Horizontal };
                TextBox tb = new TextBox { Name = "TemperatureWeekDay" + i, MinHeight = 100, MinWidth = 100 };
                TextBox tb1 = new TextBox { Name = "ProbabilityWeekDay" + i, MinHeight = 100, MinWidth = 100 };
                TextBox tb2 = new TextBox { Name = "ProbabilityWeekDay" + i, MinHeight = 100, MinWidth = 100 };
                Image ikonica = new Image { Name = "Ikonica" + i};
                tb.Text = day.Temperature;
                tb1.Text = day.Probability;
                tb2.Text = day.DateLabel;
                sp.Children.Add(tb);
                sp.Children.Add(tb1);
                sp.Children.Add(tb2);
                tab3.Children.Add(sp);
            }

            for (int i = 0; i <= 2; i++)
            {
                HourlyDisplayData.HourData hour = hdd.GetNextHourInfo();
                StackPanel sp = new StackPanel { Orientation = Orientation.Horizontal };
                TextBox tb = new TextBox { Name = "TemperatureHour" + i, MinHeight = 100, MinWidth = 100 };
                TextBox tb1 = new TextBox { Name = "ProbabilityHour" + i, MinHeight = 100, MinWidth = 100 };
                TextBox tb2 = new TextBox { Name = "TimeHour" + i, MinHeight = 100, MinWidth=100};
                Image ikonica = new Image { Name = "Ikonica" + i };
                tb.Text = hour.Time;
                tb1.Text = hour.Temperature;
                tb2.Text = hour.Probability;

                sp.Children.Add(tb);
                sp.Children.Add(tb1);
                sp.Children.Add(tb2);
                sp.Children.Add(ikonica);
                tab2.Children.Add(sp);
            }

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
                OnPropertyChanged("Probability");
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
         
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}
