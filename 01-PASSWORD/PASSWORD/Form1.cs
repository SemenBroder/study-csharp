﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASSWORD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 5000;

        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            string date = DateTime.Now.ToString("yyMM");
            string dateFromUser = textBox2.Text;
            textBox4.Text = date;
            bool areEqual = String.Equals(date, dateFromUser, StringComparison.OrdinalIgnoreCase);
            

            
            if (areEqual == true)
                textBox3.Text = "Всё получилось";
             
                
            else
                textBox3.Text = "Попробуй ёщё раз";


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = null;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
