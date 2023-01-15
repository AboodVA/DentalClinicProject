using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicProject
{
    internal class Admin
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public Admin( string username, string password) 
        {
            this.UserName = username;
            this.Password = Password;
        }
    }
}
