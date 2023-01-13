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
    public partial class EmployeeLogin : Form
    {
        public EmployeeLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePageForm form = new HomePageForm();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateInputs();

            if (!isValid)
            {
                return;
            }

            if (Backend.HandleUserLogin(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Welcome " + textBox1.Text);
            }else
            {
                MessageBox.Show("Username / password is wrong");
            }
        }

        private  bool ValidateInputs()
        {
            
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Fields empty please fill them");
                return false;
            }
            
            return true;


        }
    }
}
