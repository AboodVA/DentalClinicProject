using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;


namespace DentalClinicProject
{
    public partial class PatientListForm : Form
    {

        private static List<Patient> patients;

        public PatientListForm()
        {
            InitializeComponent();

            patients = Backend.FetchAllPatients(); 


            for (int i=0; i < patients.Count; i++)
            {
                DateTime birth = DateTime.Parse(patients[i].GetDateOfBirth());
                TimeSpan span = DateTime.Now - birth;
                int ageYears = (int)span.TotalDays / 365;

                listBox1.Items.Add($"id: {patients[i].GetID()}, {patients[i].GetName()}, {ageYears} Years old");
            }

        }

        private void PatientListForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Employee name: " + Backend.currentLoggedEmployee.GetName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
