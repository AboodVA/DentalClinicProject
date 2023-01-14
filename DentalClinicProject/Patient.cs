using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicProject
{
    internal class Patient
    {
        private int id;
        private string name;
        private string email;
        private string dateOfBirth;
        private string gender;
        private string nextAppointment;

        public Patient(string name, string email, string dateOfBirth, string gender)
        {
            this.name = name;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            id = -1;
            nextAppointment = null;

        }
        public int GetID()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public string GetEmail()
        {
            return email;
        }

        public string GetDateOfBirth()
        {
            return dateOfBirth;
        }

        public string GetGender()
        {
            return gender;
        }

        public string GetNextAppointment()
        {
            return nextAppointment;
        }

        public void SetNextAppointment(string appointment)
        {
            nextAppointment = appointment;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

    }
}
