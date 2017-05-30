using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zadanieKwalifikacyjne
{
    public class Day
    {
        public double maxtemp_c { get; set; }
        public double mintemp_c { get; set; }
        public double avgtemp_c { get; set; }
        public double maxwind_mph { get; set; }
        double maxwind_kph { get; set; }
        double totalprecip_mm { get; set; }
        double totalprecip_in { get; set; }
        double avgvis_km { get; set; }
        double avgvis_miles { get; set; }
        public double avghumidity { get; set; }
        Condition conditions { get; set; }

        public Day()
        {
            maxtemp_c = 0;
            mintemp_c = 0;
            avgtemp_c = 0;
            maxwind_mph = 0;
            maxwind_kph = 0;
        }
    }
    public class Condition
    {
        string text { get; set; }
        string icon { get; set; }//cdn.apixu.com/weather/64x64/day/353.png",
        int code { get; set; }
    }
}