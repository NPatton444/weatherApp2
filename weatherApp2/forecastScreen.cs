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
            string date1, tempAve1, tempHigh1, tempLow1, humidity1, clouds1, chanceRain1, precipType1;
            int colorPick1 = 0;

            string date2, tempAve2, tempHigh2, tempLow2, humidity2, clouds2, chanceRain2, precipType2;
            int colorPick2 = 0;

            string date3, tempAve3, tempHigh3, tempLow3, humidity3, clouds3, chanceRain3, precipType3;
            int colorPick3 = 0;

            string date4, tempAve4, tempHigh4, tempLow4, humidity4, clouds4, chanceRain4, precipType4;
            int colorPick4 = 0;

            string date5, tempAve5, tempHigh5, tempLow5, humidity5, clouds5, chanceRain5, precipType5;
            int colorPick5 = 0;

            string date6, tempAve6, tempHigh6, tempLow6, humidity6, clouds6, chanceRain6, precipType6;
            int colorPick6 = 0;

            //Set initial values for variables
            date1 = tempAve1 = tempHigh1 = tempLow1 = humidity1 = clouds1 = chanceRain1 = precipType1 = "";
            date2 = tempAve2 = tempHigh2 = tempLow2 = humidity2 = clouds2 = chanceRain2 = precipType2 = "";
            date3 = tempAve3 = tempHigh3 = tempLow3 = humidity3 = clouds3 = chanceRain3 = precipType3 = "";
            date4 = tempAve4 = tempHigh4 = tempLow4 = humidity4 = clouds4 = chanceRain4 = precipType4 = "";
            date5 = tempAve5 = tempHigh5 = tempLow5 = humidity5 = clouds5 = chanceRain5 = precipType5 = "";
            date6 = tempAve6 = tempHigh6 = tempLow6 = humidity6 = clouds6 = chanceRain6 = precipType6 = "";

            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData7Day.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;

            int day = 1;

            //check each child of the parent element
            foreach (XmlNode child in parent.ChildNodes)
            {
                if (child.Name == "forecast")
                {
                    foreach (XmlNode grandChild in child.ChildNodes)
                    {
                        foreach (XmlNode greatGrandChild in grandChild.ChildNodes)
                        {
                            if (greatGrandChild.Name == "percipitation")
                            {
                                switch (day)
                                {
                                    case 1:
                                        day++;
                                        break;
                                    case 2:
                                        precipType1 = greatGrandChild.Attributes["type"].Value;
                                        day++;
                                        break;
                                    case 3:
                                        precipType2 = greatGrandChild.Attributes["type"].Value;
                                        day++;
                                        break;
                                    case 4:
                                        precipType3 = greatGrandChild.Attributes["type"].Value;
                                        day++;
                                        break;
                                    case 5:
                                        precipType4 = greatGrandChild.Attributes["type"].Value;
                                        day++;
                                        break;
                                    case 6:
                                        precipType5 = greatGrandChild.Attributes["type"].Value;
                                        day++;
                                        break;
                                    case 7:
                                        precipType6 = greatGrandChild.Attributes["type"].Value;
                                        day++;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else if (greatGrandChild.Name == "temperature")
                            {
                                day = 1;
                                switch (day)
                                {
                                    case 1:
                                        day++;
                                        break;
                                    case 2:
                                        tempAve1 = greatGrandChild.Attributes["day"].Value;
                                        tempHigh1 = greatGrandChild.Attributes["max"].Value;
                                        tempLow1 = greatGrandChild.Attributes["min"].Value;
                                        day++;
                                        break;
                                    case 3:
                                        tempAve2 = greatGrandChild.Attributes["day"].Value;
                                        tempHigh2 = greatGrandChild.Attributes["max"].Value;
                                        tempLow2 = greatGrandChild.Attributes["min"].Value;
                                        day++;
                                        break;
                                    case 4:
                                        tempAve3 = greatGrandChild.Attributes["day"].Value;
                                        tempHigh3 = greatGrandChild.Attributes["max"].Value;
                                        tempLow3 = greatGrandChild.Attributes["min"].Value;
                                        day++;
                                        break;
                                    case 5:
                                        tempAve4 = greatGrandChild.Attributes["day"].Value;
                                        tempHigh4 = greatGrandChild.Attributes["max"].Value;
                                        tempLow4 = greatGrandChild.Attributes["min"].Value;
                                        day++;
                                        break;
                                    case 6:
                                        tempAve5 = greatGrandChild.Attributes["day"].Value;
                                        tempHigh5 = greatGrandChild.Attributes["max"].Value;
                                        tempLow5 = greatGrandChild.Attributes["min"].Value;
                                        day++;
                                        break;
                                    case 7:
                                        tempAve6 = greatGrandChild.Attributes["day"].Value;
                                        tempHigh6 = greatGrandChild.Attributes["max"].Value;
                                        tempLow6 = greatGrandChild.Attributes["min"].Value;
                                        day++;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            else if(greatGrandChild.Name == "humidity")
                            {
                                day = 1;

                                switch (day)
                                {
                                    case 1:
                                        day++;
                                        break;
                                    case 2:
                                        humidity1 = greatGrandChild.Attributes["value"].Value;
                                        day++;
                                        break;
                                    case 3:
                                        humidity2 = greatGrandChild.Attributes["value"].Value;
                                        day++;
                                        break;
                                    case 4:
                                        humidity3 = greatGrandChild.Attributes["value"].Value;
                                        day++;
                                        break;
                                    case 5:
                                        humidity4 = greatGrandChild.Attributes["value"].Value;
                                        day++;
                                        break;
                                    case 6:
                                        humidity5 = greatGrandChild.Attributes["value"].Value;
                                        day++;
                                        break;
                                    case 7:
                                        humidity6 = greatGrandChild.Attributes["value"].Value;
                                        day++;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            else if (greatGrandChild.Name == "clouds")
                            {
                                day = 1;
                                switch (day)
                                {
                                    case 1:
                                        day++;
                                        break;
                                    case 2:
                                        clouds1 = greatGrandChild.Attributes["value"].Value;
                                        chanceRain1 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    case 3:
                                        clouds2 = greatGrandChild.Attributes["value"].Value;
                                        chanceRain2 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    case 4:
                                        clouds3 = greatGrandChild.Attributes["value"].Value;
                                        chanceRain3 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    case 5:
                                        clouds4 = greatGrandChild.Attributes["value"].Value;
                                        chanceRain4 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    case 6:
                                        clouds5 = greatGrandChild.Attributes["value"].Value;
                                        chanceRain5 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    case 7:
                                        clouds6 = greatGrandChild.Attributes["value"].Value;
                                        chanceRain6 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            //Get colorBack ground and image
            ColorPicker(colorPick1, precipType1, clouds1);
            ColorPicker(colorPick2, precipType2, clouds2);
            ColorPicker(colorPick3, precipType3, clouds3);
            ColorPicker(colorPick4, precipType4, clouds4);
            ColorPicker(colorPick5, precipType5, clouds5);
            ColorPicker(colorPick6, precipType6, clouds6);

            //Get date for days
            date1 = DateTime.Now.AddDays(1).ToString("ddd-MMM-dd-yyyy");
            date2 = DateTime.Now.AddDays(2).ToString("ddd-MMM-dd-yyyy");
            date3 = DateTime.Now.AddDays(3).ToString("ddd-MMM-dd-yyyy");
            date4 = DateTime.Now.AddDays(4).ToString("ddd-MMM-dd-yyyy");
            date5 = DateTime.Now.AddDays(5).ToString("ddd-MMM-dd-yyyy");
            date6 = DateTime.Now.AddDays(6).ToString("ddd-MMM-dd-yyyy");

            //Make day objects
            Day d1 = new Day(city, date1, tempAve1, tempHigh1, tempLow1, humidity1, clouds1, chanceRain1, precipType1, colorPick1);
            Day d2 = new Day(city, date2, tempAve2, tempHigh2, tempLow2, humidity2, clouds2, chanceRain2, precipType2, colorPick2);
            Day d3 = new Day(city, date3, tempAve3, tempHigh3, tempLow3, humidity3, clouds3, chanceRain3, precipType3, colorPick3);
            Day d4 = new Day(city, date4, tempAve4, tempHigh4, tempLow4, humidity4, clouds4, chanceRain4, precipType4, colorPick4);
            Day d5 = new Day(city, date5, tempAve5, tempHigh5, tempLow5, humidity5, clouds5, chanceRain5, precipType5, colorPick5);
            Day d6 = new Day(city, date6, tempAve6, tempHigh6, tempLow6, humidity6, clouds6, chanceRain6, precipType6, colorPick6);

            //Add new day objects
            dayList.Add(d1);
            dayList.Add(d2);
            dayList.Add(d3);
            dayList.Add(d4);
            dayList.Add(d5);
            dayList.Add(d6);
        }

        public void ColorPicker(int colorPickx, string precipTypex, string cloudsx)
        {
            if (cloudsx.Equals( "overcast clouds"))
            {
                if (precipTypex.Equals("rain"))
                {
                    colorPickx = 2;
                }

                else if (precipTypex.Equals("snow"))
                {
                    colorPickx = 3;
                }

                else
                {
                    colorPickx = 0;
                }
            }

            else if (cloudsx.Equals("clear sky"))
            {
                colorPickx = 4;
            }

            else
            {
                colorPickx = 1;
            }
        }
    }
}
