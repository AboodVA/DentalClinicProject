using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinicProject
{
    public partial class CreateEmployeeForm : Form
    {
        static Regex validateEmailAddress = ValidateEmail();

        public CreateEmployeeForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePageForm form = new HomePageForm();
            form.Show();
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidateInputs())
            {

                if (Backend.HandleaUserSignUp(new Employee(textBox2.Text, textBox3.Text, textBox1.Text)))
                {

                    MessageBox.Show("User added sucessfully");

                }
                else
                {
                    MessageBox.Show("Error occured");

                }

            } else
            {

            }






        }
        private static Regex ValidateEmail()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }


        private bool ValidateInputs()
        {

            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == ""  )
            {
                MessageBox.Show("Some fields are empty, Please fill them");
                return false;
            }

            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Passwords don't match");
                return false;
            }
            


            if (validateEmailAddress.IsMatch(textBox1.Text) == true)
            {
                return true;
            }
            else
            {
                textBox1.Focus();
                MessageBox.Show("Email Address is not valid.");

                return false;
            }

            return true;

            

        }


    }

}
