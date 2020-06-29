using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            displayTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            displayTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            displayTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            displayTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            displayTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.Show();
            displayTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime tt = DateTime.Now;
            label35.Text = Convert.ToString(tt.ToUniversalTime());
        }
        private void displayTable()
        {
            ArrayList tableList = new ArrayList(); //ArrayList to store list of tables
            table t = new table();
            tableList = t.readTableFileList(); //reads tables from file to list

            for (int i = 0; i < tableList.Count; i++) //checks each table
            {
                if (i == 0) 
                { 
                    label13.Text = ((tableList[i] as table).gameStatusProperty == 0) ? "✖" : "✔"; 
                    label23.Text = Convert.ToString((tableList[i] as table).gameStatusProperty); 
                    label35.Text = ((tableList[i] as table).gameStatusProperty != 0)?Convert.ToString((tableList[i] as table).startTimeProperty.ToUniversalTime()):"-"; 
                }
                if (i == 1) 
                { 
                    label14.Text = ((tableList[i] as table).gameStatusProperty == 0) ? "✖" : "✔"; 
                    label24.Text = Convert.ToString((tableList[i] as table).gameStatusProperty); 
                    label36.Text = ((tableList[i] as table).gameStatusProperty != 0)?Convert.ToString((tableList[i] as table).startTimeProperty.ToUniversalTime()):"-"; 
                }
                if (i == 2) 
                { 
                    label15.Text = ((tableList[i] as table).gameStatusProperty == 0) ? "✖" : "✔"; 
                    label25.Text = Convert.ToString((tableList[i] as table).gameStatusProperty); 
                    label37.Text = ((tableList[i] as table).gameStatusProperty != 0)?Convert.ToString((tableList[i] as table).startTimeProperty.ToUniversalTime()):"-"; 
                }
                if (i == 3) 
                { 
                    label16.Text = ((tableList[i] as table).gameStatusProperty == 0) ? "✖" : "✔"; 
                    label26.Text = Convert.ToString((tableList[i] as table).gameStatusProperty); 
                    label38.Text = ((tableList[i] as table).gameStatusProperty != 0)?Convert.ToString((tableList[i] as table).startTimeProperty.ToUniversalTime()):"-"; 
                }
                if (i == 4) 
                { 
                    label17.Text = ((tableList[i] as table).gameStatusProperty == 0) ? "✖" : "✔"; 
                    label27.Text = Convert.ToString((tableList[i] as table).gameStatusProperty); 
                    label39.Text = ((tableList[i] as table).gameStatusProperty != 0)?Convert.ToString((tableList[i] as table).startTimeProperty.ToUniversalTime()):"-"; 
                }
                if (i == 5) 
                { 
                    label18.Text = ((tableList[i] as table).gameStatusProperty == 0) ? "✖" : "✔"; 
                    label28.Text = Convert.ToString((tableList[i] as table).gameStatusProperty); 
                    label40.Text = ((tableList[i] as table).gameStatusProperty != 0)?Convert.ToString((tableList[i] as table).startTimeProperty.ToUniversalTime()):"-"; 
                }
                if (i == 6) 
                { 
                    label19.Text = ((tableList[i] as table).gameStatusProperty == 0) ? "✖" : "✔"; 
                    label29.Text = Convert.ToString((tableList[i] as table).gameStatusProperty); 
                    label41.Text = ((tableList[i] as table).gameStatusProperty != 0)?Convert.ToString((tableList[i] as table).startTimeProperty.ToUniversalTime()):"-"; 
                }
                if (i == 7) 
                { 
                    label20.Text = ((tableList[i] as table).gameStatusProperty == 0) ? "✖" : "✔"; 
                    label30.Text = Convert.ToString((tableList[i] as table).gameStatusProperty); 
                    label42.Text = ((tableList[i] as table).gameStatusProperty != 0)?Convert.ToString((tableList[i] as table).startTimeProperty.ToUniversalTime()):"-"; 
                }
                if (i == 8) 
                { 
                    label21.Text = ((tableList[i] as table).gameStatusProperty == 0) ? "✖" : "✔"; 
                    label31.Text = Convert.ToString((tableList[i] as table).gameStatusProperty); 
                    label43.Text = ((tableList[i] as table).gameStatusProperty != 0)?Convert.ToString((tableList[i] as table).startTimeProperty.ToUniversalTime()):"-"; 
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            displayTable();
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}