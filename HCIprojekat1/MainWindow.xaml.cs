﻿using HCIprojekat1.Controllers;
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
           
            fc.ChangeToCity(txtSearchNewCity.Text);

            RefreshData();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
         
        }

    }


}
