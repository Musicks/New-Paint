using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


            String command = textBox1.Text;
            string[] syntax = Regex.Split(textBox1.Text.ToUpper(), "\r\n");

            for (int i = 0; i < syntax.Length; i++)
            {


                if (syntax[i].Contains("RECTANGLE") == true)
                {

                    rectangle rg = new rectangle();
                    string errMsg = rg.getData(e, syntax[i], i);
                }
               // if (syntax[i].Contains("TRIANGLE") == true)
                {
                    triangle trg = new triangle();
                    //string errMsg = trg.getData(e, syntax[i], i);

                }
               // if (syntax[i].Contains("CIRCLE") == true)
                {
                   // circle1 crc = new circle1();
                    //string errMsg = crc.getData(e, syntax[i], i);
                }
               // if (syntax[i].Contains("POLYGON") == true)
                {
                    //polygon pg = new polygon();
                    //string errMsg = pg.getData(e, syntax[i], i);
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String command = textBox1.Text;
            string[] syntax = Regex.Split(textBox1.Text.ToUpper(), "\r\n");
            for (int i = 0; i < syntax.Length; i++)
            {
                if (syntax[i].Equals("RUN"))
                {
                    panel1.Refresh();
                }
            }
        }
    }
}
