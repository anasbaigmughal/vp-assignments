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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player p = new player();
            if (radioButton3.Checked)
            {
                if(p.searchPlayer(textBox1.Text, 1))
                {
                    label10.Text = Convert.ToString(p.userIDProperty);
                    label11.Text = p.firstNameProperty+" "+p.lastNameProperty;
                    label12.Text = Convert.ToString(p.cnicProperty);
                    label13.Text = Convert.ToString(p.wonProperty);
                    label14.Text = Convert.ToString(p.drawProperty);
                    label15.Text = Convert.ToString(p.lostProperty );
                    label16.Text = "DONE! Player found.";
                }
                else
                {
                    label10.Text = "-";
                    label11.Text = "-";
                    label12.Text = "-";
                    label13.Text = "-";
                    label14.Text = "-";
                    label15.Text = "-";
                    label16.Text = "SORRY! Player not found.";
                }
            }
            if (radioButton2.Checked)
            {
                if (p.searchPlayer(textBox1.Text, 2))
                {
                    label10.Text = Convert.ToString(p.userIDProperty);
                    label11.Text = p.firstNameProperty + " " + p.lastNameProperty;
                    label12.Text = Convert.ToString(p.cnicProperty);
                    label13.Text = Convert.ToString(p.wonProperty);
                    label14.Text = Convert.ToString(p.drawProperty);
                    label15.Text = Convert.ToString(p.lostProperty);
                    label16.Text = "DONE! Player found.";
                }
                else
                {
                    label10.Text = "-";
                    label11.Text = "-";
                    label12.Text = "-";
                    label13.Text = "-";
                    label14.Text = "-";
                    label15.Text = "-";
                    label16.Text = "SORRY! Player not found.";
                }
            }
            if (radioButton1.Checked)
            {
                if (p.searchPlayer(textBox1.Text, 3))
                {
                    label10.Text = Convert.ToString(p.userIDProperty);
                    label11.Text = p.firstNameProperty + " " + p.lastNameProperty;
                    label12.Text = Convert.ToString(p.cnicProperty);
                    label13.Text = Convert.ToString(p.wonProperty);
                    label14.Text = Convert.ToString(p.drawProperty);
                    label15.Text = Convert.ToString(p.lostProperty);
                    label16.Text = "DONE! Player found.";
                }
                else
                {
                    label10.Text = "-";
                    label11.Text = "-";
                    label12.Text = "-";
                    label13.Text = "-";
                    label14.Text = "-";
                    label15.Text = "-";
                    label16.Text = "SORRY! Player not found.";
                }
            }
        }
    }
}
