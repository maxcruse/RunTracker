using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Tracker
{
    public class Run
    {
        public int Distance { get; set; }
        public TimeSpan Pace { get; set; }
        public double Hour { get; set; }
        public double Minute { get; set; }
        public double Second { get; set; }
        public string Date { get; set; }
        public TimeSpan Time { get; set; }


        public string Type { get; set; }
        double distance;
        double hour, minute, second;
        double pace;
    }
}
