using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            Width = 1000;
            Height = 1000;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DateTime dt = DateTime.Now;
            Pen cir_pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.Black);
            Graphics g = e.Graphics;
            GraphicsState gs;
            g.TranslateTransform(Width / 2, Height / 2);
            g.ScaleTransform(500 / 200, 500 / 200);
            g.DrawRectangle(new Pen(Color.Black), 60, -8, 20, 15);
            g.DrawString(Convert.ToString(dt.Day), new Font("Commic sans ns", 8F), new SolidBrush(Color.Red), 62, -6);
            g.DrawEllipse(cir_pen, -120, -120, 240, 240);
            gs = g.Save();
            for (int i = 0; i < 12; i++)
            {
                g.RotateTransform(30 * i);
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 5), 0, -120, 0, -100);
                g.Restore(gs);
                gs = g.Save();
            }
            for (int i = 0; i < 60; i++)
            {
                g.RotateTransform(6 * i);
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 2), 0, -120, 0, -115);
                g.Restore(gs);
                gs = g.Save();
            }
            g.RotateTransform(6 * (dt.Minute + (float)dt.Second / 60));
            g.DrawLine(new Pen(new SolidBrush(Color.Silver), 4), 0, 0, 0, -90);//минуты
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(6 * (float)dt.Second);
            g.DrawLine(new Pen(new SolidBrush(Color.Red), 1), 0, 0, 0, -115);//cекунды
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(30 * (dt.Hour + (float)dt.Minute / 60 + (float)dt.Second / 3600));
            g.DrawLine(new Pen(new SolidBrush(Color.Gold), 2), 0, 0, 0, -75);//часы
            g.Restore(gs);
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}