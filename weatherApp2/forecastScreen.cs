using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;

namespace weatherApp2
{
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();
            // get information about current and forecast weather from the internet
            GetData();

            //Take info from the current weather file and save it to day list
            ExtractCurrent();

            // take info from the forecast weather file and save it to day list
            ExtractForecast();
        }

        private static void GetData()
        {
            WebClient client = new WebClient();

            string currentFile = "http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0";
            string forecastFile = "http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0";

            //client.DownloadFile(currentFile, "WeatherData.xml");
            //client.DownloadFile(forecastFile, "WeatherData7Day.xml");
        }

        public void ExtractCurrent()
        {
            string city, date, tempAve, tempHigh, tempLow, humidity, clouds, chanceRain;
            Image[] background = new Image[7];
            Color[] backColor = new Color[7];

            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;

            //check each child of the parent element
            foreach (XmlNode child in parent.ChildNodes)
            {
                //Display Values
                if (child.Name == "city")
                {
                    city = child.Attributes["name"].Value;
                }

                if (child.Name == "temperature")
                {
                    tempHigh = child.Attributes["max"].Value;
                    tempAve = child.Attributes["value"].Value;
                    tempLow = child.Attributes["min"].Value;
                }

                if (child.Name == "humidity")
                {
                    humidity = child.Attributes["value"].Value;
                }

                if(child.Name == "weather")
                {
                    clouds = child.Attributes["value"].Value;
                }
            }
        }

        public void ExtractForecast()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData7Day.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;

            int day = 1;
        }
    }
}
