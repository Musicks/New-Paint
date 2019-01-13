using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class circle : Shape
    {
        public Rectangle circ;
        public Graphics g;

        public override double area()
        {
            throw new NotImplementedException();
        }

        protected override void fillBackground(SolidBrush s)
        {
            g.FillEllipse(s, circ);
        }
        /// <summary>
        /// This method sends the data to paint after filtering and also chooses colors
        /// </summary>
        /// <param name="e"> paint argument object</param>
        /// <param name="resultList">It saves the command in array</param>
        /// <param name="repeat">It is a radius of circle</param>
        /// <param name="line">It denotes the command in which the commands are written</param>
        /// <param name="hashtable">It is an object of HashTable</param>
        /// <returns></returns>
        private string filterdata(System.Windows.Forms.PaintEventArgs e, String[] resultList, int repeat, String line,Hashtable hashtable)
        {
            String errMsg = "";
            int val1 = 0;
            int val2 = 0;

            try
            {
                //val1 = Int32.Parse(hashtable[resultList[1]]+"");
                repeat = examHash(resultList[1], hashtable);
            }
            catch (Exception ex)
            {
                val1 = Int32.Parse(resultList[1]);
            }
            try
            {
                //val2 = Int32.Parse(hashtable[resultList[2]] + "");
                repeat = examHash(resultList[2], hashtable);
            }
            catch (Exception ex)
            {
                val2 = Int32.Parse(resultList[2]);
            }
            if (resultList.Length == 3)
            {
                paintRectangle(e, repeat, repeat, val1, val2);
                errMsg = "";
            }
            else if (resultList.Length == 4)
            {
                if (resultList[3].ToLower() == "red")
                {
                    paintRectangle(e, repeat, repeat, val1, val2);
                    fillBackground(fillRed);
                    errMsg = "";
                }
                else if (resultList[3].ToLower() == "yellow")
                {
                    paintRectangle(e, repeat, repeat, val1, val2);
                    fillBackground(fillYellow);
                    errMsg = "";
                }
                else if (resultList[3].ToLower() == "blue")
                {
                    paintRectangle(e, repeat, repeat, val1, val2);
                    fillBackground(fillBlue);
                    errMsg = "";
                }
                else
                {
                    errMsg = resultList[3] + " is not a color in line" + (line + 1);
                }
            }
            else if (resultList.Length > 4)
            {
                errMsg = "Extra Fields in line " + (line + 1);
            }

            else
            {
                errMsg = "Insufficient Fields in line " + (line + 1);
            }
            return errMsg;
        }
        /// <summary>
        /// It Paints the Circle
        /// </summary>
        /// <param name="e">Paint event argument</param>
        /// <param name="l">Radius</param>
        /// <param name="b">Radius</param>
        /// <param name="x">it is a coordinate</param>
        /// <param name="y">it is a coordinate</param>
        protected void paintRectangle(System.Windows.Forms.PaintEventArgs e, int l, int b, int x, int y)
        {
            circ = new Rectangle(x, y, l, b);
            g = e.Graphics;
            g.DrawEllipse(black, circ);
        }
        /// <summary>
        /// This method is created to validate the input that the user provides
        /// </summary>
        /// <param name="e">Paint Event Argument</param>
        /// <param name="line">It denotes the command in which the commands are written</param>
        /// <param name="i">integer</param>
        /// <param name="hashtable">It is an object of HashTable</param>
        /// <returns></returns>
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
                                val1 = Int32.Parse(hashtable[line.Substring(valFrom, valTo - valFrom)]+"");
                            }
                            catch (Exception exception)
                            {
                                val1 = Int32.Parse(line.Substring(valFrom, valTo - valFrom));
                            }
                            try
                            {
                                val2 = Int32.Parse(hashtable[line.Substring(valFrom2, valTo2 - valFrom2)]+"");
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
                                val1 = Int32.Parse(hashtable[line.Substring(valFrom3, valTo3 - valFrom3)]+"");
                            }
                            catch (Exception exception)
                            {
                                val1 = Int32.Parse(line.Substring(valFrom3, valTo3 - valFrom3));
                            }
                            try
                            {
                                val2 = Int32.Parse(hashtable[line.Substring(valFrom4, valTo4 - valFrom4)]+"");
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
                            //repeat = Int32.Parse(hashtable[resultList[0]]+"");
                            repeat = examHash(resultList[0], hashtable);
                        }
                        catch
                        {
                            repeat = Int32.Parse(resultList[0]);
                        }

                        for (int y = 0; y < val1; y++)
                        {
                            errMsg = filterdata(e, resultList, repeat, line,hashtable);
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
                            //repeat = Int32.Parse(hashtable[resultList[0]]+"");
                            repeat = examHash(resultList[0], hashtable);
                        }
                        catch
                        {
                            repeat = Int32.Parse(resultList[0]);
                        }
                        errMsg = filterdata(e, resultList, repeat, line,hashtable);
                    }
                
                }
                catch (Exception ex)
                {
                    errMsg = "Dont put empty fields or non characters in numeric fields \n" + ex;
                }

            }
            return errMsg;
        }
        /// <summary>
        /// This method is used to Unit Test the Circle
        /// </summary>
        /// <param name="i">String</param>
        /// <param name="hashtable">It is an object of HashTable</param>
        /// <returns></returns>
        public int examHash(String i, Hashtable hashtable)
        {
            int a = Int32.Parse(hashtable[i] + "");
            return a;
        }
    }
    
}
