using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Tracker
{
    public abstract class Run
    {
        //Fields
        private int _distance;
        private TimeSpan _pace;
        private string _date;
        private TimeSpan _time;
        private string _type;

        //Getters and Setters
        public int Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                this._distance = value;
            }
        }
        public TimeSpan Pace
        {
            get
            {
                return _pace;
            }
            set
            {
                this._pace = value;
            }
        }
        public TimeSpan Time
        {
            get
            {
                return _time;
            }
            set
            {
                this._time = value;
            }
        }
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                this._date = value;
            }
        }
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}
