﻿using System;
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
    public partial class AddPatientsForm : Form
    {
        static Regex validateEmailAddress = ValidateEmail();

        public AddPatientsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || dateTimePicker1.Value == null
                || (!radioButton1.Checked) && !radioButton2.Checked)
            {
                MessageBox.Show("Fields are empty");
                return;
            }

            if (!validateEmailAddress.IsMatch(textBox2.Text))
            {

                MessageBox.Show("Email address is not valid");
                return;
            }


            Patient patient = new Patient(textBox1.Text, textBox2.Text, dateTimePicker1.Text, radioButton1.Checked ? "F" : "M");

            if (Backend.HandlePatientAdd(patient))
            {
                MessageBox.Show("Patient Added sucessfully");
            }


        }

        private static Regex ValidateEmail()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }


    }
}
