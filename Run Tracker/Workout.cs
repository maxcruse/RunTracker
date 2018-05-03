using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Tracker
{
    public class Workout : Run
    {
        public int numOfIntervals { get; set; }
        TimeSpan paceOfIntervals { get; set; }
        int distOfIntervals { get; set; }
        int jogDist { get; set; }
        TimeSpan jogPace { get; set; }
        TimeSpan jogTime { get; set; }

        public Workout()
        {

        }

        public Workout(int numInt, int dist, TimeSpan pace, TimeSpan time)
        {
            numOfIntervals = numInt;
            jogDist = dist;
            jogPace = pace;
            jogTime = time;
        }

        public void CalculateRecovery(int numInt, int dist, TimeSpan pace, TimeSpan time)
        {
            numOfIntervals = numInt;
            jogDist = dist;
            jogPace = pace;
            jogTime = time;

            this.Distance = this.Distance + (this.numOfIntervals * this.jogDist);
            
        }
    }
}
