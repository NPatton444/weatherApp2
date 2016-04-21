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
        string city, date, tempAve, tempHigh, tempLow, humidity, clouds, chanceRain, precipType;
        int colorPick;
        Image[] background = new Image[5];
        Color[] backColor = new Color[5];

        //List of Days
        List<Day> dayList = new List<Day>();

        public ForecastScreen()
        {
            //Arrays of background images and colors
            background[0] = Properties.Resources.cloudy;
            background[1] = Properties.Resources.partlycloudy;
            background[2] = Properties.Resources.rainy;
            background[3] = Properties.Resources.snowy;
            background[4] = Properties.Resources.sunny;

            backColor[0] = Color.FromArgb(210, 77, 255);
            backColor[1] = Color.FromArgb(179, 179, 255);
            backColor[2] = Color.FromArgb(255, 102, 179);
            backColor[3] = Color.FromArgb(153, 187, 255);
            backColor[4] = Color.FromArgb(255, 102, 102);

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

            client.DownloadFile(currentFile, "WeatherData.xml");
            client.DownloadFile(forecastFile, "WeatherData7Day.xml");
        }

        public void ExtractCurrent()
        {
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
            date = DateTime.Now.ToString("ddd-MMM-dd-yyyy");
            ExtractCurrentRainForecast();

            if(clouds == "overcast clouds")
            {
                if (precipType == "rain")
                {
                    colorPick = 2;
                }

                else if(precipType == "snow")
                {
                    colorPick = 3;
                }

                else
                {
                    colorPick = 0;
                }
            }

            else if(clouds == "clear sky")
            {
                colorPick = 4;
            }

            else
            {
                colorPick = 1;
            }

            Day d = new Day(city, date, tempAve, tempHigh, tempLow, humidity, clouds, chanceRain, precipType, colorPick);
            dayList.Add(d);
        }

        public void ExtractCurrentRainForecast()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData7Day.xml");

            //Create node variable
            XmlNode parent;
            parent = doc.DocumentElement;

            int today = 1;
            foreach(XmlNode child in parent.ChildNodes)
            {
                if(child.Name == "forecast")
                {
                    foreach (XmlNode grandChild in child.ChildNodes)
                    {
                        if(grandChild.Name == "precipitation")
                        {
                            switch(today)
                            {
                                case 1:
                                    precipType = grandChild.Attributes["type"].Value;
                                    today++;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (grandChild.Name == "clouds")
                        {
                            today = 1;
                            switch (today)
                            {
                                case 1:
                                    chanceRain = grandChild.Attributes["all"].Value;
                                    today++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
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
