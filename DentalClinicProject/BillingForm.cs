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
    public partial class BillingForm : Form
    {
        public BillingForm()
        {
            InitializeComponent();
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Patient Name: " + Backend.currentLoggedEmployee.GetName();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double total = 0;

            try
            {
                int numOfTeehFiller = 0;
                 numOfTeehFiller = textBox1.Text != "" ? int.Parse(textBox1.Text) : 0;
                
                double teethFillerCost = (double)numOfTeehFiller * 25;

                total += teethFillerCost;

                if (checkBox1.Checked)
                {
                    total += 100;
                }

                if (checkBox2.Checked)
                {
                    total += 200;
                }

                if (checkBox3.Checked)
                {
                    total += 150;
                }


                label5.Text = $"Total {Math.Round(total, 2)} $";
                

            }catch(Exception error)
            {
                MessageBox.Show("Error Occured");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

            label5.Text = "Total 00$";

        }
    }
}
