using System;
using System.Collections;
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
        Hashtable hashtable = new Hashtable();
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
                    string errMsg = s.getData(e, syntax[i], i,hashtable);
                    textBox2.Text = errMsg;
                }
                if (syntax[i].Contains("SQUARE") == true)
                {
                    Shape s = fact.getShape("SQUARE");
                    string errMsg = s.getData(e, syntax[i], i,hashtable);
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
                    string errMsg = s.getData(e, syntax[i], i,hashtable);
                    textBox2.Text = errMsg;
                }
                if (syntax[i].Contains("INT") == true)
                {
                    if (syntax[i].Contains("=") && syntax[i].Contains(";"))
                    {
                        int valFrom2 = syntax[i].IndexOf("INT") + "INT".Length;
                        int valTo2 = syntax[i].LastIndexOf("=");

                        string val1 = "";
                        
                        val1 = syntax[i].Substring(valFrom2, valTo2 - valFrom2).Replace(" ", ""); ;

                        int valFrom1 = syntax[i].IndexOf("=") + "=".Length;
                        int valTo1 = syntax[i].LastIndexOf(";");
                        int val2 = 0;

                        val2 = Int32.Parse(syntax[i].Substring(valFrom1, valTo1 - valFrom1));

                        try
                        {
                            hashtable.Add(val1,val2);
                        }
                        catch (Exception ex)
                        {
                            hashtable[val1] = val2;
                        }
                    }
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
