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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Employee name: " + Backend.currentLoggedEmployee.GetName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientListForm form = new PatientListForm();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomePageForm form = new HomePageForm();
            this.Hide();
            form.Show();
            Backend.currentLoggedEmployee = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPatientsForm form = new AddPatientsForm();
            form.Show();
            this.Hide();

           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
