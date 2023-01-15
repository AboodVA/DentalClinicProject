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
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
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

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Fields missing");
                return;
            }

            if (Backend.HandleAdminLogin(textBox1.Text, textBox2.Text))
            {

                AdminForm form = new AdminForm();
                this.Hide();
                form.Show();

            }else
            {
                MessageBox.Show("User name or password is wrong");
            }

        }
    }
}
