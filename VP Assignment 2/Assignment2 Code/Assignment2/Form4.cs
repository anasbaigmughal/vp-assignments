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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table t = new table();
            if (t.assignNewTable(double.Parse(textBox1.Text)))
            {
                label3.Text = "DONE! Table assigned.";
            }
            else
            {
                label3.Text = "SORRY! Please wait, all tables are filled.";
            }
        }
    }
}
