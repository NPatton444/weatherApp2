using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace weatherApp2
{
    class Day
    {
        public string city, date, tempAve, tempHigh, tempLow, humidity, clouds, chanceRain;
        public Image[] background = new Image[7];
        public Color[] backColor = new Color[7];

        public Day(string _city, string _date, string _tempAve, string _tempHigh, string _tempLow, string _humidity, string _clouds, string _chanceRain, Image[] _background, Color[] _backColor)
        {
            city = _city;
            date = _date;
            tempAve = _tempAve;
            tempHigh = _tempHigh;
            tempLow = _tempLow;
            humidity = _humidity;
            clouds = _clouds;
            chanceRain = _chanceRain;
            background = _background;
            backColor = _backColor;
        }
    }
}
