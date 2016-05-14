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
            //Initialize bools
            Form1.label1Click = Form1.label2Click = Form1.label3Click = Form1.label4Click = Form1.label5Click = Form1.label6Click = Form1.label7Click = false;

            //Arrays of background images and colors
            Form1.background[0] = Properties.Resources.cloudy__1_;
            Form1.background[1] = Properties.Resources.partlycloudy__1_;
            Form1.background[2] = Properties.Resources.rainy__1_;
            Form1.background[3] = Properties.Resources.snowy__1_;
            Form1.background[4] = Properties.Resources.sunny__1_;

            Form1.backColor[0] = Color.FromArgb(131, 87, 123);
            Form1.backColor[1] = Color.FromArgb(156, 177, 168);
            Form1.backColor[2] = Color.FromArgb(209, 104, 148);
            Form1.backColor[3] = Color.FromArgb(98, 165, 208);
            Form1.backColor[4] = Color.FromArgb(219, 86, 91);

            InitializeComponent();

            // get information about current and forecast weather from the internet
            GetData();

            //Take info from the current weather file and save it to day list
            ExtractCurrent();

            // take info from the forecast weather file and save it to day list
            ExtractForecast();

            //Current Info
            dateLabel.Text = Form1.date;
            cityLabel.Text = Form1.city;
            currentTempLabel.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.tempAve))) + "°C";
            highLowTempLabel.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.tempHigh))) + "°C" + "/" + 
                Convert.ToString(Math.Round(Convert.ToDecimal(Form1.tempLow))) + "°C";
            humidityLabel.Text = "Humidity:\n" + Form1.humidity + "%";
            cloudsLabel.Text = Form1.clouds;
            if (Form1.chanceRain == "No Rain")
            {
                chancePrecipLabel.Text = Form1.chanceRain;
            }
            else
            {
                chancePrecipLabel.Text = Form1.chanceRain + "%";
            }
            windLabel.Text = "Wind:\n" + Form1.windSpeed + " m/s\n" + Form1.windDirection;
            weatherImage.BackgroundImage = Form1.background[Form1.colorPick];
            this.BackColor = Form1.backColor[Form1.colorPick];

            //Forecast Info
            day2Label.Text = Form1.date1;
            day3Label.Text = Form1.date2;
            day4Label.Text = Form1.date3;
            day5Label.Text = Form1.date4;
            day6Label.Text = Form1.date5;
            day7Label.Text = Form1.date6;
            temp2Label.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.tempAve1))) + "°C";
            temp3Label.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.tempAve2))) + "°C";
            temp4Label.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.tempAve3))) + "°C";
            temp5Label.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.tempAve4))) + "°C";
            temp6Label.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.tempAve5))) + "°C";
            temp7Label.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.tempAve6))) + "°C";
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
                    Form1.city = child.Attributes["name"].Value;
                }

                if (child.Name == "temperature")
                {
                    Form1.tempHigh = child.Attributes["max"].Value;
                    Form1.tempAve = child.Attributes["value"].Value;
                    Form1.tempLow = child.Attributes["min"].Value;
                }

                if (child.Name == "humidity")
                {
                    Form1.humidity = child.Attributes["value"].Value;
                }

                if(child.Name == "wind")
                {
                    foreach(XmlNode grandChild in child.ChildNodes)
                    {
                        if(grandChild.Name == "direction")
                        {
                            Form1.windDirection = grandChild.Attributes["name"].Value;
                        }

                        if(grandChild.Name == "speed")
                        {
                            Form1.windSpeed = grandChild.Attributes["value"].Value;
                        }
                    }
                }

                if(child.Name == "clouds")
                {
                    Form1.clouds = child.Attributes["name"].Value;
                }
            }
            Form1.date = DateTime.Now.ToString("ddd-MMM-dd-yyyy");
            ExtractCurrentRainForecast();

            if(Form1.chanceRain == null)
            {
                Form1.chanceRain = "No Rain";
            }

            Day d = new Day(Form1.city, Form1.date, Form1.tempAve, Form1.tempHigh, Form1.tempLow, Form1.humidity, Form1.clouds, Form1.chanceRain, Form1.precipType, Form1.windSpeed, Form1.windDirection, Form1.colorPick);
            Form1.DayList.Add(d);
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
                                    Form1.precipType = grandChild.Attributes["type"].Value;
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
                                    Form1.chanceRain = grandChild.Attributes["all"].Value;
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
            //Set initial values for variables
            Form1.date1 = Form1.tempAve1 = Form1.tempHigh1 = Form1.tempLow1 = Form1.humidity1 = Form1.clouds1 = Form1.chanceRain1 = Form1.precipType1 = Form1.windDirection1 = Form1.windSpeed1 =  "";
            Form1.date2 = Form1.tempAve2 = Form1.tempHigh2 = Form1.tempLow2 = Form1.humidity2 = Form1.clouds2 = Form1.chanceRain2 = Form1.precipType2 = Form1.windDirection2 = Form1.windSpeed2 = "";
            Form1.date3 = Form1.tempAve3 = Form1.tempHigh3 = Form1.tempLow3 = Form1.humidity3 = Form1.clouds3 = Form1.chanceRain3 = Form1.precipType3 = Form1.windDirection3 = Form1.windSpeed3 = "";
            Form1.date4 = Form1.tempAve4 = Form1.tempHigh4 = Form1.tempLow4 = Form1.humidity4 = Form1.clouds4 = Form1.chanceRain4 = Form1.precipType4 = Form1.windDirection4 = Form1.windSpeed4 = "";
            Form1.date5 = Form1.tempAve5 = Form1.tempHigh5 = Form1.tempLow5 = Form1.humidity5 = Form1.clouds5 = Form1.chanceRain5 = Form1.precipType5 = Form1.windDirection5 = Form1.windSpeed5 = "";
            Form1.date6 = Form1.tempAve6 = Form1.tempHigh6 = Form1.tempLow6 = Form1.humidity6 = Form1.clouds6 = Form1.chanceRain6 = Form1.precipType6 = Form1.windDirection6 = Form1.windSpeed6 = "";

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
                            if (greatGrandChild.Name == "precipitation")
                            {
                                switch (day)
                                {
                                    case 1:
                                        
                                        break;
                                    case 2:
                                        if (greatGrandChild.Attributes["type"] != null)
                                        {
                                            Form1.precipType1.Equals(greatGrandChild.Attributes["type"].Value);
                                        }
                                        else
                                        {
                                            Form1.precipType1.Equals("No Rain");
                                        }
                                        
                                        break;
                                    case 3:
                                        if (greatGrandChild.Attributes["type"] != null)
                                        {
                                            Form1.precipType2 = greatGrandChild.Attributes["type"].Value;
                                        }
                                        else
                                        {
                                            Form1.precipType2.Equals("No Rain");
                                        }
                                        
                                        break;
                                    case 4:
                                        if (greatGrandChild.Attributes["type"] != null)
                                        {
                                            Form1.precipType3 = greatGrandChild.Attributes["type"].Value;
                                        }
                                        else
                                        {
                                            Form1.precipType3.Equals("No Rain");
                                        }
                                        
                                        break;
                                    case 5:
                                        if (greatGrandChild.Attributes["type"] != null)
                                        {
                                            Form1.precipType4 = greatGrandChild.Attributes["type"].Value;
                                        }
                                        else
                                        {
                                            Form1.precipType4.Equals("No Rain");
                                        }
                                        
                                        break;
                                    case 6:
                                        if (greatGrandChild.Attributes["type"] != null)
                                        {
                                            Form1.precipType5 = greatGrandChild.Attributes["type"].Value;
                                        }
                                        else
                                        {
                                            Form1.precipType5.Equals("No Rain");
                                        }
                                        
                                        break;
                                    case 7:
                                        if (greatGrandChild.Attributes["type"] != null)
                                        {
                                            Form1.precipType6 = greatGrandChild.Attributes["type"].Value;
                                        }
                                        else
                                        {
                                            Form1.precipType6.Equals("No Rain");
                                        }
                                        
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else if(greatGrandChild.Name == "windDirection")
                            {
                                switch(day)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        Form1.windDirection1 = greatGrandChild.Attributes["name"].Value;
                                        break;
                                    case 3:
                                        Form1.windDirection2 = greatGrandChild.Attributes["name"].Value;
                                        break;
                                    case 4:
                                        Form1.windDirection3 = greatGrandChild.Attributes["name"].Value;
                                        break;
                                    case 5:
                                        Form1.windDirection4 = greatGrandChild.Attributes["name"].Value;
                                        break;
                                    case 6:
                                        Form1.windDirection5 = greatGrandChild.Attributes["name"].Value;
                                        break;
                                    case 7:
                                        Form1.windDirection6 = greatGrandChild.Attributes["name"].Value;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else if(greatGrandChild.Name == "windSpeed")
                            {
                                switch (day)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        Form1.windSpeed1 = greatGrandChild.Attributes["mps"].Value;
                                        break;
                                    case 3:
                                        Form1.windSpeed2 = greatGrandChild.Attributes["mps"].Value;
                                        break;
                                    case 4:
                                        Form1.windSpeed3 = greatGrandChild.Attributes["mps"].Value;
                                        break;
                                    case 5:
                                        Form1.windSpeed4 = greatGrandChild.Attributes["mps"].Value;
                                        break;
                                    case 6:
                                        Form1.windSpeed5 = greatGrandChild.Attributes["mps"].Value;
                                        break;
                                    case 7:
                                        Form1.windSpeed6 = greatGrandChild.Attributes["mps"].Value;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else if (greatGrandChild.Name == "temperature")
                            {
                                
                                switch (day)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        Form1.tempAve1 = greatGrandChild.Attributes["day"].Value;
                                        Form1.tempHigh1 = greatGrandChild.Attributes["max"].Value;
                                        Form1.tempLow1 = greatGrandChild.Attributes["min"].Value;
                                        
                                        break;
                                    case 3:
                                        Form1.tempAve2 = greatGrandChild.Attributes["day"].Value;
                                        Form1.tempHigh2 = greatGrandChild.Attributes["max"].Value;
                                        Form1.tempLow2 = greatGrandChild.Attributes["min"].Value;
                                        
                                        break;
                                    case 4:
                                        Form1.tempAve3 = greatGrandChild.Attributes["day"].Value;
                                        Form1.tempHigh3 = greatGrandChild.Attributes["max"].Value;
                                        Form1.tempLow3 = greatGrandChild.Attributes["min"].Value;
                                        
                                        break;
                                    case 5:
                                        Form1.tempAve4 = greatGrandChild.Attributes["day"].Value;
                                        Form1.tempHigh4 = greatGrandChild.Attributes["max"].Value;
                                        Form1.tempLow4 = greatGrandChild.Attributes["min"].Value;
                                        
                                        break;
                                    case 6:
                                        Form1.tempAve5 = greatGrandChild.Attributes["day"].Value;
                                        Form1.tempHigh5 = greatGrandChild.Attributes["max"].Value;
                                        Form1.tempLow5 = greatGrandChild.Attributes["min"].Value;
                                        
                                        break;
                                    case 7:
                                        Form1.tempAve6 = greatGrandChild.Attributes["day"].Value;
                                        Form1.tempHigh6 = greatGrandChild.Attributes["max"].Value;
                                        Form1.tempLow6 = greatGrandChild.Attributes["min"].Value;
                                        
                                        break;
                                    default:
                                        break;
                                }
                            }

                            else if(greatGrandChild.Name == "humidity")
                            {
                                

                                switch (day)
                                {
                                    case 1:
                                        
                                        break;
                                    case 2:
                                        Form1.humidity1 = greatGrandChild.Attributes["value"].Value;
                                        
                                        break;
                                    case 3:
                                        Form1.humidity2 = greatGrandChild.Attributes["value"].Value;
                                        
                                        break;
                                    case 4:
                                        Form1.humidity3 = greatGrandChild.Attributes["value"].Value;
                                        
                                        break;
                                    case 5:
                                        Form1.humidity4 = greatGrandChild.Attributes["value"].Value;
                                        
                                        break;
                                    case 6:
                                        Form1.humidity5 = greatGrandChild.Attributes["value"].Value;
                                        
                                        break;
                                    case 7:
                                        Form1.humidity6 = greatGrandChild.Attributes["value"].Value;
                                        
                                        break;
                                    default:
                                        break;
                                }
                            }

                            else if (greatGrandChild.Name == "clouds")
                            {
                                
                                switch (day)
                                {
                                    case 1:
                                        day++;
                                        break;
                                    case 2:
                                        Form1.clouds1 = greatGrandChild.Attributes["value"].Value;
                                        Form1.chanceRain1 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    case 3:
                                        Form1.clouds2 = greatGrandChild.Attributes["value"].Value;
                                        Form1.chanceRain2 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    case 4:
                                        Form1.clouds3 = greatGrandChild.Attributes["value"].Value;
                                        Form1.chanceRain3 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    case 5:
                                        Form1.clouds4 = greatGrandChild.Attributes["value"].Value;
                                        Form1.chanceRain4 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    case 6:
                                        Form1.clouds5 = greatGrandChild.Attributes["value"].Value;
                                        Form1.chanceRain5 = greatGrandChild.Attributes["all"].Value;
                                        day++;
                                        break;
                                    case 7:
                                        Form1.clouds6 = greatGrandChild.Attributes["value"].Value;
                                        Form1.chanceRain6 = greatGrandChild.Attributes["all"].Value;
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

            //Get date for days
            Form1.date1 = DateTime.Now.AddDays(1).ToString("ddd-MMM-dd-yyyy");
            Form1.date2 = DateTime.Now.AddDays(2).ToString("ddd-MMM-dd-yyyy");
            Form1.date3 = DateTime.Now.AddDays(3).ToString("ddd-MMM-dd-yyyy");
            Form1.date4 = DateTime.Now.AddDays(4).ToString("ddd-MMM-dd-yyyy");
            Form1.date5 = DateTime.Now.AddDays(5).ToString("ddd-MMM-dd-yyyy");
            Form1.date6 = DateTime.Now.AddDays(6).ToString("ddd-MMM-dd-yyyy");

            //Make day objects
            Day d1 = new Day(Form1.city, Form1.date1, Form1.tempAve1, Form1.tempHigh1, Form1.tempLow1, Form1.humidity1, Form1.clouds1, Form1.chanceRain1, Form1.precipType1, Form1.windSpeed1, Form1.windDirection1, Form1.colorPick1);
            Day d2 = new Day(Form1.city, Form1.date2, Form1.tempAve2, Form1.tempHigh2, Form1.tempLow2, Form1.humidity2, Form1.clouds2, Form1.chanceRain2, Form1.precipType2, Form1.windSpeed2, Form1.windDirection2, Form1.colorPick2);
            Day d3 = new Day(Form1.city, Form1.date3, Form1.tempAve3, Form1.tempHigh3, Form1.tempLow3, Form1.humidity3, Form1.clouds3, Form1.chanceRain3, Form1.precipType3, Form1.windSpeed3, Form1.windDirection3, Form1.colorPick3);
            Day d4 = new Day(Form1.city, Form1.date4, Form1.tempAve4, Form1.tempHigh4, Form1.tempLow4, Form1.humidity4, Form1.clouds4, Form1.chanceRain4, Form1.precipType4, Form1.windSpeed4, Form1.windDirection4, Form1.colorPick4);
            Day d5 = new Day(Form1.city, Form1.date5, Form1.tempAve5, Form1.tempHigh5, Form1.tempLow5, Form1.humidity5, Form1.clouds5, Form1.chanceRain5, Form1.precipType5, Form1.windSpeed5, Form1.windDirection5, Form1.colorPick5);
            Day d6 = new Day(Form1.city, Form1.date6, Form1.tempAve6, Form1.tempHigh6, Form1.tempLow6, Form1.humidity6, Form1.clouds6, Form1.chanceRain6, Form1.precipType6, Form1.windSpeed6, Form1.windDirection6, Form1.colorPick6);

            //Add new day objects
            Form1.DayList.Add(d1);
            Form1.DayList.Add(d2);
            Form1.DayList.Add(d3);
            Form1.DayList.Add(d4);
            Form1.DayList.Add(d5);
            Form1.DayList.Add(d6);

            for (int i = 0; i < Form1.DayList.Count(); i++)
            {
                if (Form1.DayList[i].clouds == "overcast clouds")
                {
                    if (Form1.DayList[i].chanceRain != "No Rain")
                    {
                        if (Convert.ToInt16(Form1.DayList[i].chanceRain) > 50)
                        {
                            if (Form1.DayList[i].precipType == "rain")
                            {
                                Form1.DayList[i].colorPick = 2;
                            }

                            else if (Form1.DayList[i].precipType == "snow")
                            {
                                Form1.DayList[i].colorPick = 3;
                            }
                        }
                    }

                    else
                    {
                        Form1.DayList[i].colorPick = 0;
                    }
                }

                else if (Form1.DayList[i].clouds == "clear sky")
                {
                    Form1.DayList[i].colorPick = 4;
                }

                else
                {
                    if (Form1.DayList[i].chanceRain != "No Rain")
                    {
                        if (Convert.ToInt16(Form1.DayList[i].chanceRain) > 50)
                        {
                            if (Form1.DayList[i].precipType == "rain")
                            {
                                Form1.DayList[i].colorPick = 2;
                            }

                            else if (Form1.DayList[i].precipType == "snow")
                            {
                                Form1.DayList[i].colorPick = 3;
                            }
                        }
                    }
                    else
                    {
                        Form1.DayList[i].colorPick = 1;
                    }
                }
            }
        }

        private void ForecastScreen_Paint(object sender, PaintEventArgs e)
        {
            Pen separatePen = new Pen(Color.White, 5);
            e.Graphics.DrawLine(separatePen, 0, 410, this.Width, 410);
        }

        private void dateLabel_Click(object sender, EventArgs e)
        {
            Form1.label1Click = true;
            DayScreen ds = new DayScreen();
            Form f = this.FindForm();
            f.Controls.Add(ds);
            f.Controls.Remove(this);
        }

        private void day2Label_Click(object sender, EventArgs e)
        {
            Form1.label2Click = true;
            DayScreen ds = new DayScreen();
            Form f = this.FindForm();
            f.Controls.Add(ds);
            f.Controls.Remove(this);
        }

        private void day3Label_Click(object sender, EventArgs e)
        {
            Form1.label3Click = true;
            DayScreen ds = new DayScreen();
            Form f = this.FindForm();
            f.Controls.Add(ds);
            f.Controls.Remove(this);
        }

        private void day4Label_Click(object sender, EventArgs e)
        {
            Form1.label4Click = true;
            DayScreen ds = new DayScreen();
            Form f = this.FindForm();
            f.Controls.Add(ds);
            f.Controls.Remove(this);
        }

        private void day5Label_Click(object sender, EventArgs e)
        {
            Form1.label5Click = true;
            DayScreen ds = new DayScreen();
            Form f = this.FindForm();
            f.Controls.Add(ds);
            f.Controls.Remove(this);
        }

        private void day6Label_Click(object sender, EventArgs e)
        {
            Form1.label6Click = true;
            DayScreen ds = new DayScreen();
            Form f = this.FindForm();
            f.Controls.Add(ds);
            f.Controls.Remove(this);
        }

        private void day7Label_Click(object sender, EventArgs e)
        {
            Form1.label7Click = true;
            DayScreen ds = new DayScreen();
            Form f = this.FindForm();
            f.Controls.Add(ds);
            f.Controls.Remove(this);
        }
    }
}
