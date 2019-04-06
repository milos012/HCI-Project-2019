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
        public WeatherData currently { get; set; }
        public MultiWeatherData hourly { get; set; }
        public WeatherData minutely { get; set; }
        public MultiWeatherData daily { get; set; }

        public override string ToString()
        {
            return String.Format("Full Weather API Data: latitude:{0}, longitude:{1}, timezone:{2}, currently:{3}, hourly:{4}, minutely:{5}, daily{6}", latitude, longitude, timezone, currently.ToString(), hourly.ToString(), minutely.ToString(), daily.ToString());
        }
        

    }

    class MinutelyWeatherData
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<PrecipitationWeatherData> data { get; set; }

        public override string ToString()
        {
            string datalist = "";
            int i = 1;
            foreach (PrecipitationWeatherData wd in data)
            {
                datalist += "data " + i + " " + wd.ToString() + "\n";
                i += 1;
            }
            return String.Format("Minutely Weather Data: summary:{0}, icon:{1}, data:{2}", summary, icon, datalist);
        }

    }
    
    class PrecipitationWeatherData
    {
        public int time { get; set; }
        public double precipIntensity { get; set; }
        public double precipProbability { get; set; }
        public string precipType { get; set; }


        public override string ToString()
        {
            if (precipType is null)
            {
                return String.Format("Precipitation Data: time:{0}, probability:{1}, intensity:{2}", time, precipProbability, precipIntensity);
            }
            else
            {
                return String.Format("Precipitation Data: time:{0}, probability:{1}, intensity:{2}, type:{3}", time, precipProbability, precipIntensity, precipType);
            }
            
        }
    }

    class MultiWeatherData
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<WeatherData> data { get; set; }

        public override string ToString()
        {
            string datalist = "";
            int i = 1;
            foreach (WeatherData wd in data)
            {
                datalist += "data " + i + " " + wd.ToString() + "\n";
                i += 1;
            }
            return String.Format("Hourly/Daily Weather Data: summary:{0}, icon:{1}, data:{2}", summary, icon, datalist);
        }

    }

    class WeatherData
    {
        public int time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public double precipIntensity { get; set; }
        public double precipProbability { get; set; }
        public string precipType { get; set; }
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

        public override string ToString()
        {
            return String.Format("Weather Data: time:{0}, summary:{1}, icon:{2}, precipIntensity:{3}, precipProbability:{4}, precipType:{5}, " +
                "temperature:{6}, apparentTemperature:{7}, dewPoint:{8}, humidity:{9}, pressure:{10}, windSpeed:{11}, " +
                "windGust:{12}, windBearing:{13}, cloudCover:{14}, uvIndex:{15}, visibility:{16}, ozone:{17}", time, summary, icon, precipIntensity, precipProbability, precipType, temperature, apparentTemperature, dewPoint, humidity, pressure, windSpeed, windGust, windBearing, cloudCover, uvIndex, visibility, ozone);
        }
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

        public override string ToString()
        {
            return "Moja IP adresa: " + ip + "\nMoja lokacija: " + loc + "\nGrad: " + city + "\nRegion: " + region + "\nDrzava: " + country;
        }

    }

    class CityWeatherInfo
    {
        public string lon { get; set; }
        public string lat { get; set; }
        
    }

    class ForecastApp
    {

        private static ForecastApp instance = null;

        private const string weatherURLConst = "https://api.darksky.net/forecast/817eb851837fd78c2c655a3dc70ba607";
        private string weatherURL = weatherURLConst;

        private string ipURL;
        public IpData IpAPIData { get; set; }

        public WeatherAPI AllForecastData { get; set; }

        private ForecastApp()
        {
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

        // Na osnovu prosledjenog naziva grada interno 
        // menja podatke dobijene iz Dark Spy API-a.
        public void ChangeToCity(string city)
        {
            // 1) Nalazenje latitude i longitude trazenog grada.
            string openWeatherURL = "api.openweathermap.org/data/2.5/weather?q=" + city;
            CityWeatherInfo cityWeatherInfo = JsonConvert.DeserializeObject<CityWeatherInfo>(GetJSONStringfromAPI(openWeatherURL));
            
            // 2) Azuriranje weather URL-a.
            weatherURL = weatherURLConst;
            weatherURL += "/" + cityWeatherInfo.lat + "," + cityWeatherInfo.lon + "?units=ca";

            // 3) Promena podataka na osnovu dobijenog JSON response-a.
            AllForecastData = WeatherDataFromJSON();

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
