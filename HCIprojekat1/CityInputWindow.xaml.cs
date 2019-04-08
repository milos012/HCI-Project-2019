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

namespace HCIprojekat1
{
    /// <summary>
    /// Interaction logic for CityInputWindow.xaml
    /// </summary>
    public partial class CityInputWindow : Window
    {
        private string entryResult;
        public bool isOK = false;
        public CityInputWindow()
        {
            
            InitializeComponent();
            
        }

        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            entryResult = txtAnswer.Text;
            isOK = true;
            Close();
        }

        private void BtnDialogCancel_Click(object sender, RoutedEventArgs e)
        {
            entryResult = "";
            isOK = false;
            Close();
        }
    }
}
