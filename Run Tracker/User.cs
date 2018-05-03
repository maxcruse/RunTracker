using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Tracker
{
    class User
    {
        public User()
        {

        }

        public User(string name)
        {
            this.Username = name;
        }

        public string Username { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }
    }
}
