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
        Factory fact = new Factory();

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {


            String command = textBox1.Text;
            string[] syntax = Regex.Split(textBox1.Text.ToUpper(), "\r\n");

            for (int i = 0; i < syntax.Length; i++)
            {


                if (syntax[i].Contains("RECTANGLE") == true)
                {
                    Shape s = fact.getShape("RECTANGLE");
                    string errMsg = s.getData(e, syntax[i], i);
                    textBox2.Text = errMsg;
                }
                if (syntax[i].Contains("SQUARE") == true)
                {
                    Shape s = fact.getShape("SQUARE");
                    string errMsg = s.getData(e, syntax[i], i);
                    textBox2.Text = errMsg;
                }
                // if (syntax[i].Contains("TRIANGLE") == true)
                {
                    triangle trg = new triangle();
                    //string errMsg = trg.getData(e, syntax[i], i);

                }
               if (syntax[i].Contains("CIRCLE") == true)
                {
                    Shape s = fact.getShape("CIRCLE");
                    string errMsg = s.getData(e, syntax[i], i);
                    textBox2.Text = errMsg;
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
