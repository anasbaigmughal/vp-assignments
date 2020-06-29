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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            table t = new table();
            t.submitTableResults(int.Parse(textBox1.Text), 1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            table t = new table();
            button2.Text = "Player-1: " + Convert.ToString(t.playerOneID(int.Parse(textBox1.Text)));
            button3.Text = "Player-2: " + Convert.ToString(t.playerTwoID(int.Parse(textBox1.Text)));
            int tab = int.Parse(textBox1.Text);
            if (tab == 1 || tab == 2 || tab == 3 || tab == 4 || tab == 5 || tab == 6 || tab == 7 || tab == 8 || tab == 9)
            {
                label3.Text = "DONE! Table found.";
            }
            else
            {
                label3.Text = "ERROR! Table not found.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            table t = new table();
            t.submitTableResults(int.Parse(textBox1.Text), 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            table t = new table();
            t.submitTableResults(int.Parse(textBox1.Text), 3);
        }
    }
}
