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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table t = new table();
            if (t.assignNewTable(double.Parse(textBox1.Text), double.Parse(textBox2.Text)))
            {
                label4.Text = "DONE! Table assigned.";
            }
            else
            {
                label4.Text = "SORRY! Please wait, all tables are filled.";
            }
        }
    }
}
