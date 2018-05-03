using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Tracker
{
    class User
    {
        //Fields
        private string _username;

        //Getters and Setters
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                this._username = value;
            }
        }

        //Constructors
        public User()
        {

        }

        public User(string name)
        {
            this.Username = name;
        }               
    }
}
