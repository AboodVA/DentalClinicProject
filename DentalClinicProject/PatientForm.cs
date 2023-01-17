using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinicProject
{
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Backend.currentSelectedPatient = null;
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {

            dateTimePicker1.MinDate = DateTime.Now;

            DateTime birth = DateTime.Parse(Backend.currentSelectedPatient.GetDateOfBirth());
            TimeSpan span = DateTime.Now - birth;
            int ageYears = (int)span.TotalDays / 365;


            label2.Text = "ID: " + Backend.currentSelectedPatient.GetID();
            label3.Text = "Name: " + Backend.currentSelectedPatient.GetName();
            label4.Text = "Age:  " + ageYears + "Years old";
            label5.Text = "Email: " + Backend.currentSelectedPatient.GetEmail();
            label6.Text = "Gender: " + Backend.currentSelectedPatient.GetGender();

            label7.Text = "Next appointment:\n" + Backend.GetPatientAppointment();

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            BillingForm billingForm = new BillingForm();
            billingForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
            {
                MessageBox.Show("No appointments in friday");
                return;
            }
            
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Please select a time");
                return;
            }

            string time = "";

            time = radioButton1.Checked ? "8:00 AM" : time ;
            time = radioButton2.Checked ? "11:00 AM" : time;
            time = radioButton3.Checked ? "1:00 PM" : time;




            string format = $"{Backend.currentSelectedPatient.GetID()},{dateTimePicker1.Value.ToString("dd/MM/yyyy")},{time}";



            if (Backend.AddAppointment(format))
            {
                MessageBox.Show("Appointment Added sucssesfully");
                label7.Text = "Next appointment:\n" + Backend.GetPatientAppointment();

            }
            else
            {

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Backend.RemovePatientAppointment();
            
            label7.Text = "Next appointment:\n" + Backend.GetPatientAppointment();

        }
    }
}
