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

    }
}
