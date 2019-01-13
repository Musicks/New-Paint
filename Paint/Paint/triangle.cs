using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class triangle : Shape
    {
        public Graphics g;

        public override double area()
        {
            throw new NotImplementedException();
        }

        public override string getData(PaintEventArgs e, string line, int i, Hashtable hashtable)
        {
            string errMsg = "";
            if (line.Contains("[") && line.Contains("]") && line.Contains(","))
            {
                int valueFrom = line.IndexOf("[") + "[".Length;
                int valueTo = line.LastIndexOf("]");

                String result = line.Substring(valueFrom, valueTo - valueFrom);

                result = result.Replace(" ", String.Empty);

                string[] resultList = Regex.Split(result, ",");
                try
                {
                    int val1 = 0;
                    int val2 = 0;
                    Boolean addition = true;
                    if (line.Contains("REPEAT") && line.Contains(";"))
                    {
                        if (line.Contains("+"))
                        {
                            int valFrom = line.IndexOf("REPEAT") + "REPEAT".Length;
                            int valTo = line.LastIndexOf("+");

                            int valFrom2 = line.IndexOf("+") + "+".Length;
                            int valTo2 = line.LastIndexOf(";");

                            try
                            {
                                val1 = Int32.Parse(hashtable[line.Substring(valFrom, valTo - valFrom)] + "");
                            }
                            catch (Exception exception)
                            {
                                val1 = Int32.Parse(line.Substring(valFrom, valTo - valFrom));
                            }
                            try
                            {
                                val2 = Int32.Parse(hashtable[line.Substring(valFrom2, valTo2 - valFrom2)] + "");
                            }
                            catch (Exception exception)
                            {
                                val2 = Int32.Parse(line.Substring(valFrom2, valTo2 - valFrom2));
                            }
                            addition = true;
                        }
                        else if (line.Contains("-"))
                        {
                            int valFrom3 = line.IndexOf("REPEAT") + "REPEAT".Length;
                            int valTo3 = line.LastIndexOf("-");

                            int valFrom4 = line.IndexOf("-") + "-".Length;
                            int valTo4 = line.LastIndexOf(";");

                            try
                            {
                                val1 = Int32.Parse(hashtable[line.Substring(valFrom3, valTo3 - valFrom3)] + "");
                            }
                            catch (Exception exception)
                            {
                                val1 = Int32.Parse(line.Substring(valFrom3, valTo3 - valFrom3));
                            }
                            try
                            {
                                val2 = Int32.Parse(hashtable[line.Substring(valFrom4, valTo4 - valFrom4)] + "");
                            }
                            catch (Exception exception)
                            {
                                val2 = Int32.Parse(line.Substring(valFrom4, valTo4 - valFrom4));
                            }
                            addition = false;


                        }
                        else
                        {
                            errMsg = "Invalid Syntax. Please Write The Code Properly." + (line + 1);
                        }


                    }


                    if (val1 != 0 && val2 != 0)
                    {
                        int repeat1 = 0;
                        int repeat2 = 0;
                        int repeat3 = 0;
                        int repeat4 = 0;
                        int repeat5 = 0;
                        int repeat6 = 0;
                        try
                        {
                            repeat1 = Int32.Parse(hashtable[resultList[0]] + "");
                            repeat2 = Int32.Parse(hashtable[resultList[1]] + "");
                            repeat3 = Int32.Parse(hashtable[resultList[2]] + "");
                            repeat4 = Int32.Parse(hashtable[resultList[3]] + "");
                            repeat5 = Int32.Parse(hashtable[resultList[4]] + "");
                            repeat6 = Int32.Parse(hashtable[resultList[5]] + "");
                        }
                        catch
                        {
                            repeat1 = Int32.Parse(resultList[0]);
                            repeat2 = Int32.Parse(resultList[1]);
                            repeat3 = Int32.Parse(resultList[2]);
                            repeat4 = Int32.Parse(resultList[3]);
                            repeat5 = Int32.Parse(resultList[4]);
                            repeat6 = Int32.Parse(resultList[5]);
                        }

                        for (int y = 0; y < val1; y++)
                        {
                            errMsg = manageData(e, resultList, repeat1, repeat2, repeat3, repeat4, repeat5, repeat6, line, hashtable);
                            if (addition == true)
                            {
                                repeat1 = repeat1 + val1;
                                repeat2 = repeat2 + val1;
                                repeat3 = repeat3 + val1;
                                repeat4 = repeat4 + val1;
                                repeat4 = repeat4 + val1;
                                repeat5 = repeat5 + val1;
                                repeat6 = repeat6 + val1;
                            }
                            else
                            {
                                repeat1 = repeat1 - val1;
                                repeat2 = repeat2 - val1;
                                repeat3 = repeat3 - val1;
                                repeat4 = repeat4 - val1;
                                repeat4 = repeat4 - val1;
                                repeat5 = repeat5 - val1;
                                repeat6 = repeat6 - val1;
                            }
                        }

                    }
                    else
                    {
                        int repeat1 = 0;
                        int repeat2 = 0;
                        int repeat3 = 0;
                        int repeat4 = 0;
                        int repeat5 = 0;
                        int repeat6 = 0;
                        try
                        {
                            repeat1 = Int32.Parse(hashtable[resultList[0]] + "");
                            repeat2 = Int32.Parse(hashtable[resultList[1]] + "");
                            repeat3 = Int32.Parse(hashtable[resultList[2]] + "");
                            repeat4 = Int32.Parse(hashtable[resultList[3]] + "");
                            repeat5 = Int32.Parse(hashtable[resultList[4]] + "");
                            repeat6 = Int32.Parse(hashtable[resultList[5]] + "");
                        }
                        catch
                        {
                            repeat1 = Int32.Parse(resultList[0]);
                            repeat2 = Int32.Parse(resultList[1]);
                            repeat3 = Int32.Parse(resultList[2]);
                            repeat4 = Int32.Parse(resultList[3]);
                            repeat5 = Int32.Parse(resultList[4]);
                            repeat6 = Int32.Parse(resultList[5]);
                        }
                        errMsg = manageData(e, resultList, repeat1, repeat2, repeat3, repeat4, repeat5, repeat6, line, hashtable);
                    }
                }
                catch (Exception ex)
                {
                    errMsg = "Dont put empty fields or non characters in numeric fields \n" + ex;
                }

            }
            return errMsg;
        }

        private String manageData(PaintEventArgs e, string[] resultList, int repeat1, int repeat2, int repeat3, int repeat4, int repeat5, int repeat6, string line, Hashtable hashTable)
        {

            string errMsg = "";
            int x = 0; int y = 0;

            if (resultList.Length == 6)
            {

                paintTriangle(e, repeat1, repeat2, repeat3, repeat4, repeat5, repeat6, resultList, fillBlack);
                errMsg = "";
            }
            else if (resultList.Length == 7)
            {
                if (resultList[6] == "red")
                {

                    paintTriangle(e, repeat1, repeat2, repeat3, repeat4, repeat5, repeat6, resultList, fillRed);

                    errMsg = "";

                }
                else if (resultList[6] == "yellow")
                {
                    paintTriangle(e, repeat1, repeat2, repeat3, repeat4, repeat5, repeat6, resultList, fillYellow);

                    errMsg = "";
                }
                else if (resultList[6] == "blue")
                {
                    paintTriangle(e, repeat1, repeat2, repeat3, repeat4, repeat5, repeat6, resultList, fillBlue);

                    errMsg = "";
                }
                else
                {
                    errMsg = resultList[6] + " is not a color in line - " + (line + 1);
                }
            }
            else if (resultList.Length > 7)
            {
                errMsg = "Extra Fields in line - " + (line + 1);
            }
            else
            {
                errMsg = "Insufficient Fields in line - " + (line + 1);
            }
            return errMsg;
        }

        protected void paintTriangle(System.Windows.Forms.PaintEventArgs e, int a, int b, int c, int d, int f, int g, String[] resultList, SolidBrush s)
        {
            Point[] points = { new Point(a, b), new Point(c, d), new Point(f, g) };
            e.Graphics.DrawPolygon(black, points);
            if (resultList.Length == 7)
            {
                e.Graphics.FillPolygon(s, points);
            }
        }


        protected override void fillBackground(SolidBrush s)
        {
            throw new NotImplementedException();
        }
    }
}
