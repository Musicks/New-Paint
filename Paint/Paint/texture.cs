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
    class texture : Shape
    {
        public Rectangle rec;
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
                        int repeat = 0;
                        try
                        {
                            repeat = Int32.Parse(hashtable[resultList[0]] + "");
                        }
                        catch
                        {
                            repeat = Int32.Parse(resultList[0]);
                        }

                        for (int y = 0; y < val1; y++)
                        {
                            errMsg = filterdata(e, resultList, repeat, line, hashtable);
                            if (addition == true)
                            {
                                repeat = repeat + val1;
                            }
                            else
                            {
                                repeat = repeat - val1;
                            }
                        }

                    }
                    else
                    {
                        int repeat = 0;
                        try
                        {
                            repeat = Int32.Parse(hashtable[resultList[0]] + "");
                        }
                        catch
                        {
                            repeat = Int32.Parse(resultList[0]);
                        }
                        errMsg = filterdata(e, resultList, repeat, line, hashtable);
                    }
                }
                catch (Exception ex)
                {
                    errMsg = "Dont put empty fields or non characters in numeric fields \n" + ex;
                }

            }
            return errMsg;
        }
        private String filterdata(PaintEventArgs e, string[] resultList, int repeat, string line, Hashtable hashTable)
        {

            string errMsg = "";
            int x = 0; int y = 0;

            if (resultList.Length == 3)
            {
                try
                {
                    x = Int32.Parse(hashTable[resultList[1]] + "");
                }
                catch (Exception ex)
                {
                    x = Int32.Parse(resultList[1]);
                }
                try
                {
                    y = Int32.Parse(hashTable[resultList[2]] + "");
                }
                catch (Exception ex)
                {
                    y = Int32.Parse(resultList[2]);
                }
                paintSquare(e, repeat, repeat, x, y);
                errMsg = "";
            }
            /*
            else if (resultList.Length == 4)
            {
                if (resultList[3] == "red")
                {
                    try
                    {
                        x = Int32.Parse(hashTable[resultList[1]] + "");
                    }
                    catch (Exception ex)
                    {
                        x = Int32.Parse(resultList[1]);
                    }
                    try
                    {
                        y = Int32.Parse(hashTable[resultList[2]] + "");
                    }
                    catch (Exception ex)
                    {
                        y = Int32.Parse(resultList[2]);
                    }
                    paintSquare(e, repeat, repeat, x, y);
                    BackgroundFill(fillRed);
                    errMsg = "";

                }
                else if (resultList[3] == "yellow")
                {
                    paintSquare(e, repeat, repeat, x, y);
                    BackgroundFill(fillYellow);
                    errMsg = "";
                }
                else if (resultList[3] == "blue")
                {
                    paintSquare(e, repeat, repeat, x, y);
                    BackgroundFill(fillBlue);
                    errMsg = "";
                }
                else
                {
                    errMsg = resultList[3] + " is not a color in line - " + (line + 1);
                }
            }
            */
            else if (resultList.Length > 4)
            {
                errMsg = "Extra Fields in line - " + (line + 1);
            }
            else
            {
                errMsg = "Insufficient Fields in line - " + (line + 1);
            }
            return errMsg;
        }

        protected override void fillBackground(SolidBrush s)
        {
            throw new NotImplementedException();
        }

        protected void paintSquare(System.Windows.Forms.PaintEventArgs e, int w, int h, int x, int y)
        {
            rec = new Rectangle(x, y, h, w);
            g = e.Graphics;

            Bitmap bitmap = new Bitmap("C:/Users/Baula/Downloads/download.jpg");
            TextureBrush tBrush = new TextureBrush(bitmap);
            Pen texturedPen = new Pen(tBrush, 30);

            g.DrawRectangle(texturedPen, rec);
        }
        
    }
}
