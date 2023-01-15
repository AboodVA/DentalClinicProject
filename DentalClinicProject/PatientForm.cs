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

            DateTime birth = DateTime.Parse(Backend.currentSelectedPatient.GetDateOfBirth());
            TimeSpan span = DateTime.Now - birth;
            int ageYears = (int)span.TotalDays / 365;


            label2.Text = "ID: " + Backend.currentSelectedPatient.GetID();
            label3.Text = "Name: " + Backend.currentSelectedPatient.GetName();
            label4.Text = "Age " + ageYears;
            label5.Text = "Email: " + Backend.currentSelectedPatient.GetEmail();
            label6.Text = "Gender: " + Backend.currentSelectedPatient.GetGender();

            label7.Text = "Next appointment: " + (Backend.currentSelectedPatient.GetNextAppointment() == null ? "No appointment" : Backend.currentSelectedPatient.GetNextAppointment());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BillingForm billingForm = new BillingForm();
            billingForm.Show();
        }
    }
}
