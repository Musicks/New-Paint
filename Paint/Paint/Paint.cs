﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Paint : Form
    {
        private bool mouseDown = false;
        private Point lastPoint = Point.Empty;
        private string color = "black";
        private Graphics g;
        private Pen p;
        public Paint()
        {
           
            InitializeComponent();
            g = CreateGraphics();
            p = new Pen(Color.FromName(color));

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(808, 542);
            this.MaximizeBox = false;
            this.Name = "frmScribble";
            this.Text = "Scribble";
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseDown = true;
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(0, new MenuItem("black", new EventHandler(RightMouseButton_Click)));
                m.MenuItems.Add(1, new MenuItem("white", new EventHandler(RightMouseButton_Click)));
                m.MenuItems.Add(2, new MenuItem("red", new EventHandler(RightMouseButton_Click)));
                m.MenuItems.Add(3, new MenuItem("green", new EventHandler(RightMouseButton_Click)));
                m.MenuItems.Add(4, new MenuItem("blue", new EventHandler(RightMouseButton_Click)));
                m.Show(this, new Point(e.X, e.Y));
            }
        }

        protected void RightMouseButton_Click(object sender, EventArgs e)
        {
            color = ((MenuItem)sender).Text;
            p = new Pen(Color.FromName(color));
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseDown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (lastPoint.Equals(Point.Empty)) lastPoint = new Point(e.X, e.Y);
            if (mouseDown)
            {
                Point pMousePos = new Point(e.X, e.Y);
                g.DrawLine(p, pMousePos, lastPoint);
            }
            lastPoint = new Point(e.X, e.Y);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            this.Close();
            Paint p = new Paint();
            p.Show();
        }

       
    }
}
