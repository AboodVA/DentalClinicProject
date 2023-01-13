using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicProject
{
    internal class Employee
    {

        private int id;
        private string name;
        private string password;
        private string email;


        public Employee(string name, string password, string email)
        {
            this.name = name;
            this.password = password;
            this.email = email;
        }


        public int GetID()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetEmail() 
        {
            return email;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

    }
}
