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

            forecast = new ForecastApp();
            

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (forecast.AllForecastData.minutely is null)
            {
                MessageBox.Show("greska ima kms");
            }else
            {
                txtBox1.Text = forecast.AllForecastData.minutely.ToString();
            }
            
            
        }
    }
}
