﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public abstract class Shape
    {
        public string name;

        protected Pen red = new Pen(Color.Red);
        protected Pen blue = new Pen(Color.Blue);
        protected Pen yellow = new Pen(Color.Yellow);
        protected Pen black = new Pen(Color.Black);

        protected System.Drawing.SolidBrush fillRed = new System.Drawing.SolidBrush(Color.Red);
        protected System.Drawing.SolidBrush fillBlue = new System.Drawing.SolidBrush(Color.Blue);
        protected System.Drawing.SolidBrush fillYellow = new System.Drawing.SolidBrush(Color.Yellow);

        public abstract double area();
        protected abstract void fillBackground(SolidBrush s);
    }
}
