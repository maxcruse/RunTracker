using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Tracker
{
    public class Workout : Run
    {
        //Fields
        private int _numOfIntervals;
        private TimeSpan _paceOfIntervals;
        private int _distOfIntervals;
        private int _jogDist;
        private TimeSpan _jogPace;
        private TimeSpan _jogTime;

        //Getters and Setters
        public int NumOfIntervals
        {
            get
            {
                return _numOfIntervals;
            }
            set
            {
                this._numOfIntervals = value;
            }
        }
        public TimeSpan PaceOfIntervals
        {
            get
            {
                return _paceOfIntervals;
            }
            set
            {
                this._paceOfIntervals = value;
            }
        }
        public int DistOfIntervals
        {
            get
            {
                return _distOfIntervals;
            }
            set
            {
                this._distOfIntervals = value;
            }
        }
        public int JogDist
        {
            get
            {
                return _jogDist;
            }
            set
            {
                this._jogDist = value;
            }
        }
        public TimeSpan JogPace
        {
            get
            {
                return _jogPace;
            }
            set
            {
                this._jogPace = value;
            }
        }
        public TimeSpan JogTime
        {
            get
            {
                return _jogTime;
            }
            set
            {
                this._jogTime = value;
            }
        }

        //Constructors
        public Workout()
        {
            
        }
        
        //Methods
        public void CalculateWithRecovery()
        {
            Distance = (this._distOfIntervals * this._numOfIntervals) + (this._numOfIntervals * this._jogDist);
            Time = TimeSpan.FromTicks(this.Time.Ticks + (this._jogTime.Ticks * this._numOfIntervals));
            Pace = this._paceOfIntervals;
        }
        public void CalculateNoRecovery()
        {
            Distance = this._distOfIntervals * this._numOfIntervals;
            Pace = this._paceOfIntervals;
        }
    }
}
