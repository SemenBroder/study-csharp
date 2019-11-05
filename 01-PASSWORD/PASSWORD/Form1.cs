using System;
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
            
            textBox4.Text = DateTime.Now.ToString(" yyyy.MMM ");

            if ( textBox2.Text == textBox4.Text)
            {
                textBox3.Text = "Vse poluchilos";

            }
            else
            {
                textBox3.Text = "Poprobuy escho";
            }

            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = null;
        }
    }
}
