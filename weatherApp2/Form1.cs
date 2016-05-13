using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weatherApp2
{
    public partial class Form1 : Form
    {
        public static string city, date, tempAve, tempHigh, tempLow, humidity, clouds, chanceRain, precipType, windSpeed, windDirection;
        public static int colorPick;
        public static Image[] background = new Image[5];
        public static Color[] backColor = new Color[5];

        //Forecast Variables
        public static string date1, tempAve1, tempHigh1, tempLow1, humidity1, clouds1, chanceRain1, precipType1, windSpeed1, windDirection1;
        public static int colorPick1 = 0;

        public static string date2, tempAve2, tempHigh2, tempLow2, humidity2, clouds2, chanceRain2, precipType2, windSpeed2, windDirection2;
        public static int colorPick2 = 0;

        public static string date3, tempAve3, tempHigh3, tempLow3, humidity3, clouds3, chanceRain3, precipType3, windSpeed3, windDirection3;
        public static int colorPick3 = 0;

        public static string date4, tempAve4, tempHigh4, tempLow4, humidity4, clouds4, chanceRain4, precipType4, windSpeed4, windDirection4;
        public static int colorPick4 = 0;

        public static string date5, tempAve5, tempHigh5, tempLow5, humidity5, clouds5, chanceRain5, precipType5, windSpeed5, windDirection5;
        public static int colorPick5 = 0;

        public static string date6, tempAve6, tempHigh6, tempLow6, humidity6, clouds6, chanceRain6, precipType6, windSpeed6, windDirection6;
        public static int colorPick6 = 0;

        //Click Booleans
        public static bool label1Click, label2Click, label3Click, label4Click, label5Click, label6Click, label7Click;

        //List of Days
        private static List<Day> dayList = new List<Day>();

        internal static List<Day> DayList
        {
            get
            {
                return dayList;
            }

            set
            {
                dayList = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
            ForecastScreen fs = new ForecastScreen();
            this.Controls.Add(fs);
        }
    }
}
