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
        public string city, date, tempAve, tempHigh, tempLow, humidity, clouds, chanceRain, precipType;
        int colorPick;

        public Day(string _city, string _date, string _tempAve, string _tempHigh, string _tempLow, string _humidity, string _clouds, string _chanceRain, string _precipType, int _colorPick)
        {
            city = _city;
            date = _date;
            tempAve = _tempAve;
            tempHigh = _tempHigh;
            tempLow = _tempLow;
            humidity = _humidity;
            clouds = _clouds;
            chanceRain = _chanceRain;
            precipType = _precipType;
            colorPick = _colorPick;
        }
    }
}
