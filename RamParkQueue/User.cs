using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamParkQueue
{
    public class User
    {
        public int RAM_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private int ram_points;
        public int RAM_Points
        {
            get
            {
                return ram_points;
            }
            //Only allow 0-10 RAM Points scale
            set
            {
                if (value <= 100 && value>= 0)
                {
                    ram_points = value;
                }
            }
        }
        //Password must be hashed in future. This is very insecure
        public string Password { get; set; }
        public string Phone { get; set; }

        public User() { }
        public User(int ramId, string fName, string lName, string email, string password, string phone)
        {
            RAM_ID = ramId;
            FirstName = fName;
            LastName = lName;
            Email = email;
            //Points Closer to 0 = higher priority in queue
            RAM_Points = 10;
            Password = password;
            Phone = phone;
        }
        public override string ToString()
        {
            return FirstName + ", " + LastName + ", RAM POINTS: " + RAM_Points;
        }
    }
}
