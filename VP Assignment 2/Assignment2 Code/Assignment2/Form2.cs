using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
                    }

        private void button1_Click(object sender, EventArgs e)
        {
            player p = new player();
            if (!p.createNewPlayer(double.Parse(textBox1.Text), textBox2.Text, textBox3.Text, double.Parse(textBox4.Text)))
            {
                label6.Text = "ERROR! Player-ID already registered.";
            }
            else
            {
                label6.Text = "DONE! Player succesfully registered.";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
