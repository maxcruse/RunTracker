using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Tracker
{
    class User
    {
        #region Fields
        private string _username;
        #endregion Fields

        #region Getters and Setters
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
        #endregion Getters and Setters

        #region Constructors
        public User()
        {

        }

        public User(string name)
        {
            this.Username = name;
        }
        #endregion Constructors
    }
}
