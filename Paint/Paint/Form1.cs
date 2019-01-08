using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String command = textBox1.Text;
            string[] syntax = command.Split('\n');
            int i = syntax.Length;
            int count = 0;
            while (count < i)
            {

                string[] text = syntax[count].Split(' ');
                if (text[0].ToUpper().Equals("DRAW"))
                {

                    string[] param = text[2].Split(',');
                    if (text[1].ToUpper().Equals("RECTANGLE"))
                    {
                        int parameter1 = Convert.ToInt32(param[0]);
                        int parameter2 = Convert.ToInt32(param[1]);
                        int parameter3 = Convert.ToInt32(param[2]);
                        int parameter4 = Convert.ToInt32(param[3]);
                        MessageBox.Show("Draw rectangle with parameter" + parameter1 + "and" + parameter2);
                    }
                    if (text[1].ToUpper().Equals("TRIANGLE"))
                    {
                        int parameter1 = Convert.ToInt32(param[0]);
                        int parameter2 = Convert.ToInt32(param[1]);
                        int parameter3 = Convert.ToInt32(param[2]);
                        int parameter4 = Convert.ToInt32(param[3]);
                        MessageBox.Show("Draw triangle with parameter" + parameter1 + "and" + parameter2);
                    }
                    if (text[1].ToUpper().Equals("CIRCLE"))
                    {
                        int parameter1 = Convert.ToInt32(param[0]);
                        int parameter2 = Convert.ToInt32(param[1]);
                        int parameter3 = Convert.ToInt32(param[2]);
                        int parameter4 = Convert.ToInt32(param[3]);
                        MessageBox.Show("Draw circle with parameter" + parameter1 + "and" + parameter2);
                    }
                    if (text[1].ToUpper().Equals("POLYGON"))
                    {
                        int parameter1 = Convert.ToInt32(param[0]);
                        int parameter2 = Convert.ToInt32(param[1]);
                        int parameter3 = Convert.ToInt32(param[2]);
                        int parameter4 = Convert.ToInt32(param[3]);
                        MessageBox.Show("Draw polygon with parameter" + parameter1 + "and" + parameter2);
                    }
                }
                count++;
            }
        }
    }
}
