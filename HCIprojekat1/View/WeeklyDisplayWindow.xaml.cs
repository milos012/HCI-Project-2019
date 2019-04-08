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
                _Probability = d.Probability;
                Verovatnoca.DataContext = this;
                
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
    }
}
