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
            if (ForecastScreen.label2Click)
            {
                dateLabel.Text = ForecastScreen.date1;
                currentTempLabel.Text = ForecastScreen.tempAve1;
                highLowTempLabel.Text = ForecastScreen.tempHigh1 + "/" + ForecastScreen.tempLow1;
                humidityLabel.Text = ForecastScreen.humidity1;
                cloudsLabel.Text = ForecastScreen.clouds1;
                chancePrecipLabel.Text = ForecastScreen.chanceRain1;
                weatherImage.BackgroundImage = ForecastScreen.background[ForecastScreen.colorPick1];
                this.BackColor = ForecastScreen.backColor[ForecastScreen.colorPick1];
            }

            else if (ForecastScreen.label3Click)
            {
                dateLabel.Text = ForecastScreen.date2;
                currentTempLabel.Text = ForecastScreen.tempAve2;
                highLowTempLabel.Text = ForecastScreen.tempHigh2 + "/" + ForecastScreen.tempLow2;
                humidityLabel.Text = ForecastScreen.humidity2;
                cloudsLabel.Text = ForecastScreen.clouds2;
                chancePrecipLabel.Text = ForecastScreen.chanceRain2;
                weatherImage.BackgroundImage = ForecastScreen.background[ForecastScreen.colorPick2];
                this.BackColor = ForecastScreen.backColor[ForecastScreen.colorPick2];
            }

            else if (ForecastScreen.label4Click)
            {
                dateLabel.Text = ForecastScreen.date3;
                currentTempLabel.Text = ForecastScreen.tempAve3;
                highLowTempLabel.Text = ForecastScreen.tempHigh3 + "/" + ForecastScreen.tempLow3;
                humidityLabel.Text = ForecastScreen.humidity3;
                cloudsLabel.Text = ForecastScreen.clouds3;
                chancePrecipLabel.Text = ForecastScreen.chanceRain3;
                weatherImage.BackgroundImage = ForecastScreen.background[ForecastScreen.colorPick3];
                this.BackColor = ForecastScreen.backColor[ForecastScreen.colorPick3];
            }

            else if (ForecastScreen.label5Click)
            {
                dateLabel.Text = ForecastScreen.date4;
                currentTempLabel.Text = ForecastScreen.tempAve4;
                highLowTempLabel.Text = ForecastScreen.tempHigh4 + "/" + ForecastScreen.tempLow4;
                humidityLabel.Text = ForecastScreen.humidity4;
                cloudsLabel.Text = ForecastScreen.clouds4;
                chancePrecipLabel.Text = ForecastScreen.chanceRain4;
                weatherImage.BackgroundImage = ForecastScreen.background[ForecastScreen.colorPick4];
                this.BackColor = ForecastScreen.backColor[ForecastScreen.colorPick4];
            }

            else if (ForecastScreen.label6Click)
            {
                dateLabel.Text = ForecastScreen.date5;
                currentTempLabel.Text = ForecastScreen.tempAve5;
                highLowTempLabel.Text = ForecastScreen.tempHigh5 + "/" + ForecastScreen.tempLow5;
                humidityLabel.Text = ForecastScreen.humidity5;
                cloudsLabel.Text = ForecastScreen.clouds5;
                chancePrecipLabel.Text = ForecastScreen.chanceRain5;
                weatherImage.BackgroundImage = ForecastScreen.background[ForecastScreen.colorPick5];
                this.BackColor = ForecastScreen.backColor[ForecastScreen.colorPick5];
            }

            else if (ForecastScreen.label7Click)
            {
                dateLabel.Text = ForecastScreen.date6;
                currentTempLabel.Text = ForecastScreen.tempAve6;
                highLowTempLabel.Text = ForecastScreen.tempHigh6 + "/" + ForecastScreen.tempLow6;
                humidityLabel.Text = ForecastScreen.humidity6;
                cloudsLabel.Text = ForecastScreen.clouds6;
                chancePrecipLabel.Text = ForecastScreen.chanceRain6;
                weatherImage.BackgroundImage = ForecastScreen.background[ForecastScreen.colorPick6];
                this.BackColor = ForecastScreen.backColor[ForecastScreen.colorPick6];
            }
        }
    }
}
