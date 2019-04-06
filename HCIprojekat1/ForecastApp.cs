using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Sockets;
using HtmlAgilityPack;

namespace HCIprojekat1
{
    class WeatherAPI
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string timezone { get; set; }
        public CurrentWeatherData currently { get; set; }
        public HourlyWeather hourly { get; set; }
        public DailyWeather daily { get; set; }        

    }

    class WeatherData
    {
        public double time { get; set; }
        public double precipIntensity { get; set; }
        public double precipProbability { get; set; }
        public string precipType { get; set; }

    }

    class  CurrentWeatherData : WeatherData
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public string temperature { get; set; }
        public string apparentTemperature { get; set; }
        public string dewPoint { get; set; }
        public string humidity { get; set; }
        public string pressure { get; set; }
        public string windSpeed { get; set; }
        public string windGust { get; set; }
        public string windBearing { get; set; }
        public string cloudCover { get; set; }
        public string uvIndex { get; set; }
        public string visibility { get; set; }
        public string ozone { get; set; }

    }

    class MinutelynWeatherData : WeatherData
    { 
        
    }

    class DailyWeatherData : WeatherData
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public string pressure { get; set; }
        public double precipIntensityMax { get; set; }
        public double precipIntensityMaxTime { get; set; }
        public string windSpeed { get; set; }
        public string windGust { get; set; }
        public string windBearing { get; set; }
        public string cloudCover { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double temperatureMin { get; set; }
        public double temperatureMinTime { get; set; }
        public double temperatureMax { get; set; }
        public double temperatureMaxTime { get; set; }
        public double apparentTemperatureMax { get; set; }
        public double apparentTemperatureMaxTime { get; set; }
        public double apparentTemperatureMin { get; set; }
        public double apparentTemperatureMinTime { get; set; }
        public double temperatureLow { get; set; }
        public double temperatureLowTime { get; set; }
        public double temperatureHigh { get; set; }
        public double temperatureHighTime { get; set; }
        public double apparentTemperatureHigh { get; set; }
        public double apparentTemperatureHighTime { get; set; }
        public double apparentTemperatureLow { get; set; }
        public double apparentTemperatureLowTime { get; set; }
        public int uvIndex { get; set; }
        public double visibility { get; set; }
        public double ozone { get; set; }

    }


    class WeatherWrapper
    {
        public string summary { get; set; }
        public string icon { get; set; }
        
    }

    class MinutelyWeather : WeatherWrapper
    {
        public List<MinutelynWeatherData> data { get; set; }


    }


    class CurrentlyWeather :WeatherWrapper
    {
        public List<CurrentWeatherData> data { get; set; }

    }

    class DailyWeather : WeatherWrapper
    {
        public List<DailyWeatherData> data { get; set; }

    }

    class HourlyWeather : WeatherWrapper
    {
        public List<CurrentWeatherData> data { get; set; }

    }


    class IpData
    {
        public string ip { get; set; }
        public string loc { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }

        public IpData()
        {

        }

        public IpData(string ajpi, string coords, string grad, string reg, string drzava)
        {
            ip = ajpi;
            loc = coords;
            city = grad;
            region = reg;
            country = drzava;
        }

    }

    class ForecastApp
    {

        private static ForecastApp instance = null;

        private string weatherURL = "https://api.darksky.net/forecast/817eb851837fd78c2c655a3dc70ba607";

        private string ipURL;
        public IpData IpAPIData { get; set; }

        public WeatherAPI AllForecastData { get; set; }

        private HttpClient Client;


        private ForecastApp()
        {
            HttpClient client = new HttpClient();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            string myIP = ParseMyIP();
            SetIPURL("https://ipinfo.io/" + myIP + "/geo?token=3fbd29417bcda3");
            IpAPIData = IPDataInstanceFromJSON();
            weatherURL += "/" + IpAPIData.loc + "?units=ca";
            AllForecastData = WeatherDataFromJSON();
            
        }

        public static ForecastApp GetInstance()
        {
            if (instance == null)
            {
                return new ForecastApp();
            }
            else
            {
                return instance;
            }
        }

        public void SetClient(HttpClient client)
        {
            Client = client;
        }

        public HttpClient GetClient()
        {
            return Client;
        }

        public string GetWeatherURL()
        {
            return weatherURL;
        }

        public string GetIPURL()
        {
            return ipURL;
        }

        public void SetIPURL(string url)
        {
            ipURL = url;
        }


        public string GetJSONStringfromAPI(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        public IpData IPDataInstanceFromJSON()
        {
            IpData ipdata = JsonConvert.DeserializeObject<IpData>(GetJSONStringfromAPI(ipURL));
            return ipdata;
        }

        public WeatherAPI WeatherDataFromJSON()
        {
            WeatherAPI data = JsonConvert.DeserializeObject<WeatherAPI>(GetJSONStringfromAPI(GetWeatherURL()));
            return data;
        }

        public string ParseMyIP()
        {
            var html = "http://checkip.dyndns.org/";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

            string ip = node.OuterHtml;
            return ip.Substring(26, 13);
        }
    }
}
