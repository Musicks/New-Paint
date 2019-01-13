using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            Boolean loop = false;
            int loop_num = 0;
            int indexfrom = 0;
            int indexto = 0;

            int if_num = 0;
            string hashvalue = "";
            int ifindexfrom = 0;
            int ifindexto = 0;

            Boolean ifCase = false;

            String command = textBox1.Text;
            string[] syntax = Regex.Split(textBox1.Text.ToUpper(), "\r\n");

            for (int i = 0; i < syntax.Length; i++)
            {
                if (syntax[i].Contains("LOOP") == true && syntax[i].Contains(":") == true && loop == false)
                {
                    indexfrom = i;
                    loop = true;
                    int pFrom = syntax[i].IndexOf("LOOP") + "LOOP".Length;
                    int pTo = syntax[i].LastIndexOf(":");

                    loop_num = Int32.Parse(syntax[i].Substring(pFrom, pTo - pFrom));
                }
                else if (syntax[i].Contains("ENDLOOP") == true)
                {
                    indexto = i;
                    for (int b = 0; b < loop_num; b++)
                    {
                        
                        for (int a = indexfrom; a < indexto; a++)
                        {
                            validate_data(syntax, a, e);
                        }
                    }
                    loop = false;
                    loop_num = 0;
                    indexfrom = 0;
                    indexto = 0;
                }
                else if (syntax[i].Contains("IF") == true && syntax[i].Contains(":") == true && syntax[i].Contains("==") == true)
                {
                    ifCase = true;

                    ifindexfrom = i;
                    int pFrom = syntax[i].IndexOf("IF") + "IF".Length;
                    int pTo = syntax[i].LastIndexOf("==");

                    hashvalue = syntax[i].Substring(pFrom, pTo - pFrom);
                    hashvalue = hashvalue.Replace(" ", String.Empty);
                    int pFrom1 = syntax[i].IndexOf("==") + "==".Length;
                    int pTo1 = syntax[i].LastIndexOf(":");

                    if_num = Int32.Parse(syntax[i].Substring(pFrom1, pTo1 - pFrom1));
                }
                else if (syntax[i].Contains("ENDIF"))
                {
                    ifindexto = i;

                    if (Int32.Parse(hashtable[hashvalue] + "") == if_num)
                    {
                        for (int a = ifindexfrom; a < ifindexto; a++)
                        {
                            validate_data(syntax, a, e);
                        }
                    }
                    ifindexfrom = 0;
                    ifindexto = 0;
                    ifCase = false;
                }
                else if (syntax[i].Contains("IF") == true && syntax[i].Contains("-") && syntax[i].Contains(";") == true && syntax[i].Contains("==") == true)
                {
                    int pFrom = syntax[i].IndexOf("IF") + "IF".Length;
                    int pTo = syntax[i].LastIndexOf("==");

                    string hashv = syntax[i].Substring(pFrom, pTo - pFrom);
                    int pFrom1 = syntax[i].IndexOf("==") + "==".Length;
                    int pTo1 = syntax[i].LastIndexOf("-");

                    int val = Int32.Parse(syntax[i].Substring(pFrom1, pTo1 - pFrom1));

                    if (Int32.Parse(hashtable[hashv] + "") == val)
                    {
                        validate_data(syntax, i, e);
                    }
                }
                else if (ifCase == false && syntax[i].Contains("IF") == false)
                {
                    validate_data(syntax, i, e);
                }
            }

        }

        private void validate_data(String [] line, int i, PaintEventArgs e )
        {
            if (line[i].Contains("RECTANGLE") == true)
            {
                Shape s = fact.getShape("RECTANGLE");
                string errMsg = s.getData(e, line[i], i, hashtable);
                textBox2.Text = errMsg;
            }
            if (line[i].Contains("SQUARE") == true)
            {
                Shape s = fact.getShape("SQUARE");
                string errMsg = s.getData(e, line[i], i, hashtable);
                textBox2.Text = errMsg;
            }
            if (line[i].Contains("TRIANGLE") == true)
            {
                Shape s = fact.getShape("TRIANGLE");
                string errMsg = s.getData(e, line[i], i, hashtable);
                textBox2.Text = errMsg;

            }
            if (line[i].Contains("CIRCLE") == true)
            {
                Shape s = fact.getShape("CIRCLE");
                string errMsg = s.getData(e, line[i], i, hashtable);
                textBox2.Text = errMsg;
            }
            if (line[i].Contains("++")==true)
            {
                int pFrom = line[i].IndexOf("++") + "++".Length;
                int pTo = line[i].LastIndexOf(";");

                int res = Int32.Parse(line[i].Substring(pFrom, pTo - pFrom));

                string[] hash = line[i].Split(new string[] { "++" }, StringSplitOptions.None);
                hash[0] = hash[0].Replace(" ", "");
                try
                {
                    hashtable[hash[0]] = Int32.Parse(hashtable[hash[0]] + "") + res;
                }
                catch (Exception x)
                {

                }
            }

            if (line[i].Contains("TEXTURE") == true)
            {
                Shape s = fact.getShape("TEXTURE");
                string errMsg = s.getData(e, line[i], i, hashtable);
                textBox2.Text = errMsg;
            }
            if (line[i].Contains("INT") == true)
            {
                if (line[i].Contains("=") && line[i].Contains(";"))
                {
                    int valFrom2 = line[i].IndexOf("INT") + "INT".Length;
                    int valTo2 = line[i].LastIndexOf("=");

                    string val1 = "";

                    val1 = line[i].Substring(valFrom2, valTo2 - valFrom2).Replace(" ", ""); ;

                    int valFrom1 = line[i].IndexOf("=") + "=".Length;
                    int valTo1 = line[i].LastIndexOf(";");
                    int val2 = 0;

                    val2 = Int32.Parse(line[i].Substring(valFrom1, valTo1 - valFrom1));

                    try
                    {
                        hashtable.Add(val1, val2);
                    }
                    catch (Exception ex)
                    {
                        hashtable[val1] = val2;
                    }
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = Path.ChangeExtension(dialog.FileName, ".txt");
                using (var fs = File.Create(path))
                using (StreamWriter bw = new StreamWriter(fs))
                {
                    bw.Write(textBox1.Text);
                    bw.Close();
                }

            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog1.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
                textBox1.Text = fileContent;
            }
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paint p = new Paint();
            p.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
