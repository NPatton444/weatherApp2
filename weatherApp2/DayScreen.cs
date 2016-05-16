using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weatherApp2
{
    public partial class DayScreen : UserControl
    {
        public DayScreen()
        {
            InitializeComponent();
        }

        private void DayScreen_Load(object sender, EventArgs e)
        {
            if (Form1.label1Click)
            {
                dateLabel.Text = Form1.DayList[0].date;
                highLowTempLabel.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[0].tempHigh))) + "°C"
                    + "/" + Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[0].tempLow))) + "°C";
                humidityLabel.Text = "Humidity:\n" + Form1.DayList[0].humidity + "%";
                cloudsLabel.Text = Form1.DayList[0].clouds;
                if (Form1.chanceRain == "No Rain")
                {
                    chancePrecipLabel.Text = Form1.DayList[0].chanceRain;
                }
                else
                {
  
                    chancePrecipLabel.Text = "Chance of Rain:\n" + Form1.DayList[0].chanceRain + "%";
                }
                windLabel.Text = "Wind:\n" + Form1.DayList[0].windSpeed + " m/s\n" + Form1.DayList[0].windDirection;
                weatherImage.BackgroundImage = Form1.background[Form1.DayList[0].colorPick];
                this.BackColor = Form1.backColor[Form1.DayList[0].colorPick];
            }

            else if (Form1.label2Click)
            {
                dateLabel.Text = Form1.DayList[1].date;
                highLowTempLabel.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[1].tempHigh))) + "°C"
                    + "/" + Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[1].tempLow))) + "°C";
                humidityLabel.Text = "Humidity:\n" + Form1.DayList[1].humidity + "%";
                cloudsLabel.Text = Form1.DayList[1].clouds;
                if (Form1.DayList[1].chanceRain == "No Rain")
                {
                    chancePrecipLabel.Text = Form1.DayList[1].chanceRain;
                }
                else
                {

                    chancePrecipLabel.Text = "Chance of Rain:\n" + Form1.DayList[1].chanceRain + "%";
                }
                windLabel.Text = "Wind:\n" + Form1.DayList[1].windSpeed + " m/s\n" + Form1.DayList[1].windDirection;
                weatherImage.BackgroundImage = Form1.background[Form1.DayList[1].colorPick];
                this.BackColor = Form1.backColor[Form1.DayList[1].colorPick];
            }

            else if (Form1.label3Click)
            {
                dateLabel.Text = Form1.DayList[2].date;
                highLowTempLabel.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[2].tempHigh))) + "°C"
                    + "/" + Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[2].tempLow))) + "°C";
                humidityLabel.Text = "Humidity:\n" + Form1.DayList[2].humidity + "%";
                cloudsLabel.Text = Form1.DayList[2].clouds;
                if (Form1.DayList[2].chanceRain == "No Rain")
                {
                    chancePrecipLabel.Text = Form1.DayList[2].chanceRain;
                }
                else
                {

                    chancePrecipLabel.Text = "Chance of Rain:\n" + Form1.DayList[2].chanceRain + "%";
                }
                windLabel.Text = "Wind:\n" + Form1.DayList[2].windSpeed + " m/s\n" + Form1.DayList[2].windDirection;
                weatherImage.BackgroundImage = Form1.background[Form1.DayList[2].colorPick];
                this.BackColor = Form1.backColor[Form1.DayList[2].colorPick];
            }

            else if (Form1.label4Click)
            {
                dateLabel.Text = Form1.DayList[3].date;
                highLowTempLabel.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[3].tempHigh))) + "°C"
                    + "/" + Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[3].tempLow))) + "°C";
                humidityLabel.Text = "Humidity:\n" + Form1.DayList[3].humidity + "%";
                cloudsLabel.Text = Form1.DayList[3].clouds;
                if (Form1.DayList[3].chanceRain == "No Rain")
                {
                    chancePrecipLabel.Text = Form1.DayList[3].chanceRain;
                }
                else
                {

                    chancePrecipLabel.Text = "Chance of Rain:\n" + Form1.DayList[3].chanceRain + "%";
                }
                windLabel.Text = "Wind:\n" + Form1.DayList[3].windSpeed + " m/s\n" + Form1.DayList[3].windDirection;
                weatherImage.BackgroundImage = Form1.background[Form1.DayList[3].colorPick];
                this.BackColor = Form1.backColor[Form1.DayList[3].colorPick];
            }

            else if (Form1.label5Click)
            {
                dateLabel.Text = Form1.DayList[4].date;
                highLowTempLabel.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[4].tempHigh))) + "°C"
                    + "/" + Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[4].tempLow))) + "°C";
                humidityLabel.Text = "Humidity:\n" + Form1.DayList[4].humidity + "%";
                cloudsLabel.Text = Form1.DayList[4].clouds;
                if (Form1.DayList[4].chanceRain == "No Rain")
                {
                    chancePrecipLabel.Text = Form1.DayList[4].chanceRain;
                }
                else
                {

                    chancePrecipLabel.Text = "Chance of Rain:\n" + Form1.DayList[4].chanceRain + "%";
                }
                windLabel.Text = "Wind:\n" + Form1.DayList[4].windSpeed + " m/s\n" + Form1.DayList[4].windDirection;
                weatherImage.BackgroundImage = Form1.background[Form1.DayList[4].colorPick];
                this.BackColor = Form1.backColor[Form1.DayList[4].colorPick];
            }

            else if (Form1.label6Click)
            {
                dateLabel.Text = Form1.DayList[5].date;
                highLowTempLabel.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[5].tempHigh))) + "°C"
                    + "/" + Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[5].tempLow))) + "°C";
                humidityLabel.Text = "Humidity:\n" + Form1.DayList[5].humidity + "%";
                cloudsLabel.Text = Form1.DayList[5].clouds;
                if (Form1.DayList[5].chanceRain == "No Rain")
                {
                    chancePrecipLabel.Text = Form1.DayList[5].chanceRain;
                }
                else
                {

                    chancePrecipLabel.Text = "Chance of Rain:\n" + Form1.DayList[5].chanceRain + "%";
                }
                windLabel.Text = "Wind:\n" + Form1.DayList[5].windSpeed + " m/s\n" + Form1.DayList[5].windDirection;
                weatherImage.BackgroundImage = Form1.background[Form1.DayList[5].colorPick];
                this.BackColor = Form1.backColor[Form1.DayList[5].colorPick];
            }

            else if (Form1.label7Click)
            {
                dateLabel.Text = Form1.DayList[6].date;
                highLowTempLabel.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[6].tempHigh))) + "°C"
                    + "/" + Convert.ToString(Math.Round(Convert.ToDecimal(Form1.DayList[6].tempLow))) + "°C";
                humidityLabel.Text = "Humidity:\n" + Form1.DayList[6].humidity + "%";
                cloudsLabel.Text = Form1.DayList[6].clouds;
                if (Form1.DayList[6].chanceRain == "No Rain")
                {
                    chancePrecipLabel.Text = Form1.DayList[6].chanceRain;
                }
                else
                {

                    chancePrecipLabel.Text = "Chance of Rain:\n" + Form1.DayList[6].chanceRain + "%";
                }
                windLabel.Text = "Wind:\n" + Form1.DayList[6].windSpeed + " m/s\n" + Form1.DayList[6].windDirection;
                weatherImage.BackgroundImage = Form1.background[Form1.DayList[6].colorPick];
                this.BackColor = Form1.backColor[Form1.DayList[6].colorPick];
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ForecastScreen fs = new ForecastScreen();
            Form f = this.FindForm();
            f.Controls.Add(fs);
            f.Controls.Remove(this);
        }
    }
}
