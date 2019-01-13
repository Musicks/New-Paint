using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class rectangle : Shape
    {
        public Rectangle rect;
        public Graphics g;
        public override double area()
        {
            throw new NotImplementedException();
        }

        protected override void fillBackground(SolidBrush s)
        {
            g.FillRectangle(s, rect);
        }
        protected void paintRectangle(System.Windows.Forms.PaintEventArgs e, int l, int b, int x, int y)
        {
            rect = new Rectangle(x, y, l, b);
            g = e.Graphics;
            g.DrawRectangle(black, rect);
        }

        private string filterdata(System.Windows.Forms.PaintEventArgs e, String[] resultList, int repeat, int repeat1, String line, Hashtable hashtable)
        {
            String errMsg = "";
            int val1 = 0;
            int val2 = 0;

            try
            {
                //val1 = Int32.Parse(hashtable[resultList[2]] + "");
                val1 = examHash(resultList[2], hashtable);
                
            }
            catch (Exception ex)
            {
                val1 = Int32.Parse(resultList[2]);
            }
            try
            {
                //val2 = Int32.Parse(hashtable[resultList[3]] + "");
                val2 = examHash(resultList[3], hashtable);
            }
            catch (Exception ex)
            {
                val2 = Int32.Parse(resultList[3]);
            }
            if (resultList.Length == 4)
            {
                paintRectangle(e, repeat, repeat1, val1, val2);
                errMsg = "";
            }
            else if (resultList.Length == 5)
            {
                if (resultList[4].ToLower() == "red")
                {
                    paintRectangle(e, repeat, repeat1, val1, val2);
                    fillBackground(fillRed);
                    errMsg = "";
                }
                else if (resultList[4].ToLower() == "yellow")
                {
                    paintRectangle(e, repeat, repeat1, val1, val2);
                    fillBackground(fillYellow);
                    errMsg = "";
                }
                else if (resultList[4].ToLower() == "blue")
                {
                    paintRectangle(e, repeat, repeat1, val1, val2);
                    fillBackground(fillBlue);
                    errMsg = "";
                }
                else
                {
                    errMsg = resultList[4] + " is not a color in line" + (line + 1);
                }
            }
            else if (resultList.Length > 5)
            {
                errMsg = "Extra Fields in line " + (line + 1);
            }

            else
            {
                errMsg = "Insufficient Fields in line " + (line + 1);
            }
            return errMsg;
        }

        public override String getData(System.Windows.Forms.PaintEventArgs e, String line, int i,Hashtable hashtable)
        {
            string errMsg = "";
            if (line.Contains("[") && line.Contains("]") && line.Contains(","))
            {
                int From = line.IndexOf("[") + "[".Length;
                int To = line.LastIndexOf("]");

                String result = line.Substring(From, To - From);

                result = result.Replace(" ", String.Empty);

                string[] resultList = result.Split(',');
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
                        int repeat = 0;
                        int repeat1 = 0;
                        try
                        {
                            //repeat = Int32.Parse(hashtable[resultList[repeat]] + "");
                            //repeat1 = Int32.Parse(hashtable[resultList[repeat1]] + "");
                            repeat = examHash(resultList[0], hashtable);
                            repeat1 = examHash(resultList[1], hashtable);
                        }
                        catch
                        {
                            repeat = Int32.Parse(resultList[repeat]);
                            repeat1 = Int32.Parse(resultList[repeat1]);
                        }

                        for (int y = 0; y < val1; y++)
                        {
                            errMsg = filterdata(e, resultList, repeat, repeat1, line, hashtable);
                            if (addition == true)
                            {
                                repeat = repeat + val1;
                                repeat1 = repeat1 + val1;
                            }
                            else
                            {
                                repeat = repeat - val1;
                                repeat1 = repeat1 + val1;
                            }
                        }

                    }
                    else
                    {
                        int repeat = 0;
                        int repeat1 = 0;
                        try
                        {
                            //repeat = Int32.Parse(hashtable[resultList[0]] + "");
                            //repeat1 = Int32.Parse(hashtable[resultList[1]] + "");
                            repeat = examHash(resultList[0], hashtable);
                            repeat1 = examHash(resultList[1], hashtable);
                        }
                        catch
                        {
                            repeat = Int32.Parse(resultList[0]);
                            repeat1 = Int32.Parse(resultList[1]);
                        }
                        errMsg = filterdata(e, resultList, repeat, repeat1, line, hashtable);
                    }

                }
                catch (Exception ex)
                {
                    errMsg = "Dont put empty fields or non characters in numeric fields \n" + ex;
                }

            }
            return errMsg;
        }
        public int examHash(String i, Hashtable hashtable)
        {
            int a = Int32.Parse(hashtable[i] + "");
            return a;
        }
    }
}
