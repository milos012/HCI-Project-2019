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

namespace HCIprojekat1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ForecastApp forecast;
        public MainWindow()
        {
            InitializeComponent();


            ForecastController fc = new ForecastController();
            CurrentlyDisplayData c = fc.GetCurrentData();

            _TemperatureInfo = c.TemperatureInfo;
            Temperatura.DataContext = this;
            _Location = c.Location;
            Lokacija.DataContext = this;
            _Date = c.Date;
            Datum.DataContext = this;

            _Source = c.Icon;
            Ikonica.DataContext = this;

            _Message = c.Message;
            Poruka.DataContext = this;
            _Probability = c.Probability;
            Verovatnoca.DataContext = this;

            forecast = ForecastApp.GetInstance();
            

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.

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

        private void refreshData()
        {
            
        }

        private void ChangeCityButtonClick(object sender, RoutedEventArgs e)
        {
            
            CityInputWindow cityInput = new CityInputWindow();
            
            cityInput.Show();
            while(true)
            
            {
                if (cityInput.isOK)
                {
                    break;
                }
            }
            MessageBox.Show(cityInput.txtAnswer.Text);
            //forecast.ChangeToCity("Novi Sad");
            //refreshData();
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

    }
}
