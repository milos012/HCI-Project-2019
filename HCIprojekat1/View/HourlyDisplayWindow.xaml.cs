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
            HourlyDisplayData h = fc.GetHourlyData();

        }

       
    }
}
