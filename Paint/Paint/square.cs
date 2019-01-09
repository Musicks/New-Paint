using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class square : Shape
    {
        public Rectangle sqr;
        public Graphics g;
        public override double area()
        {
            throw new NotImplementedException();
        }

        protected override void fillBackground(SolidBrush s)
        {
            throw new NotImplementedException();
        }

        protected void paintRectangle(System.Windows.Forms.PaintEventArgs e, int l, int b, int x, int y)
        {
            sqr = new Rectangle(x, y, l, b);
            g = e.Graphics;
            g.DrawRectangle(black, sqr);
        }

        public String getData(System.Windows.Forms.PaintEventArgs e, String line, int i)
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
                    if (resultList.Length == 3)
                    {
                        paintRectangle(e, Int32.Parse(resultList[0]), Int32.Parse(resultList[1]), Int32.Parse(resultList[2]), Int32.Parse(resultList[2]));
                        errMsg = "";
                    }
                    else if (resultList.Length == 5)
                    {
                        if (resultList[4].ToLower() == "red")
                        {
                            paintRectangle(e, Int32.Parse(resultList[0]), Int32.Parse(resultList[1]), Int32.Parse(resultList[2]), Int32.Parse(resultList[3]));
                            fillBackground(fillRed);
                            errMsg = "";
                        }
                        else if (resultList[4].ToLower() == "yellow")
                        {
                            paintRectangle(e, Int32.Parse(resultList[0]), Int32.Parse(resultList[1]), Int32.Parse(resultList[2]), Int32.Parse(resultList[3]));
                            fillBackground(fillYellow);
                            errMsg = "";
                        }
                        else if (resultList[4].ToLower() == "blue")
                        {
                            paintRectangle(e, Int32.Parse(resultList[0]), Int32.Parse(resultList[1]), Int32.Parse(resultList[2]), Int32.Parse(resultList[3]));
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
                }
                catch (Exception ex)
                {
                    errMsg = "Dont put empty fields or non characters in numeric fields \n" + ex;
                }

            }
            return errMsg;
        }
    }
}
