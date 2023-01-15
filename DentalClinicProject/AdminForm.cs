using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinicProject
{
    public partial class AdminForm : Form
    {

        private static List<Patient> patients;
        private static List<Employee> employees;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            UpdateLists();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Backend.currentLoggedInAdmin = null;
            this.Close();
            HomePageForm form = new HomePageForm();
            form.Show();
        }

        private void UpdateLists()
        {

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            patients = Backend.FetchAllPatients();


            for (int i = 0; i < patients.Count; i++)
            {
                DateTime birth = DateTime.Parse(patients[i].GetDateOfBirth());
                TimeSpan span = DateTime.Now - birth;
                int ageYears = (int)span.TotalDays / 365;

                listBox1.Items.Add($"{patients[i].GetID()},{patients[i].GetName()},{ageYears} Years old");
            }


            employees = Backend.FetchAllEmployees();

            for (int i = 0; i < employees.Count; i++)
            {


                listBox2.Items.Add($"{employees[i].GetID()},{employees[i].GetName()}");
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string data = listBox1.SelectedItem.ToString();
            MessageBox.Show(data);

            int id = int.Parse(data.Split(",")[0]);
            string name = data.Split(",")[1];
            */

            DialogResult result = MessageBox.Show("Sure you want to remove?: " +  "?", "Continue", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

              //  Backend.HandleRemoveAccount(id,"employee.txt");

            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }
    }
}
