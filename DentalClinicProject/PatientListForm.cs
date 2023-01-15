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

                listBox1.Items.Add($"{patients[i].GetID()},{patients[i].GetName()},{ageYears} Years old");
            }

        }

        private void PatientListForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Employee name: " + Backend.currentLoggedEmployee.GetName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeForm form = new EmployeeForm();
            form.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string patientData = listBox1.SelectedItem.ToString();
            
            int patientID = int.Parse(patientData.Split(",")[0]);
            string name = patientData.Split(",")[1];

            DialogResult result =  MessageBox.Show("Want to view patient: " + name + "?", "Continue", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                Backend.HandleSelectedPatient(patientID);

                PatientForm form = new PatientForm();
                form.Show();
                


            }
            else if (result == DialogResult.No)
            {
                return;
            }

        }
    }
}
