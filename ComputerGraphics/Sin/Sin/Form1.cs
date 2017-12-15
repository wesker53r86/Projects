using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int xlim { get; set; }
        public static int ylim { get; set; }
        public float xdis = 40;
        public float ydis = 4;
        public class Array
        {
            public float value;
            public Array next;
            
        }
        public void GetY(Array x, ref Array y)
        {
            double temp;
            double xval = (double)x.value;
            temp = Math.Sin(xval);
            temp = temp / xval;
            y.value = (float)temp;
        }
        public void CreateArrayX(ref Array start)
        {
            float temp;
            float incr;
            start = null;          
            temp = xlim;
            temp = temp / xdis;
            incr = 1;
            incr = incr / temp;
            for (int i = 0; i <= xlim; i++)
            {
                float g = new float();
                Array x = new Array();
                g = -(xdis/2) + (i * incr);
                x.value = g;
                addNode(ref start, x);
            }
        }
        public void CreateAxis(ref Graphics g)
        {
            int xl=0, xr=0, yu=0, yd=0;
            xl = (int)xdis;
            xr = xl / 2;
            xl = -xr;
            yu = (int)ydis;
            yu = yu / 2;
            yd = -yu;
            string a, b, c, d;
            a = xl.ToString();
            b = xr.ToString();
            c = yu.ToString();
            d = yd.ToString();
            PointF cb = new PointF(),cd = new PointF();
            Color setcolor = Color.FromArgb(200,0,0);
            SolidBrush abrush = new SolidBrush(setcolor);
            Pen newpen = new Pen(abrush);
            cb.X = -(xdis/2);
            cb.Y = 0;
            ConverttoScreen(ref cb);
            cd.X = xdis / 2;
            cd.Y = 0;
            ConverttoScreen(ref cd);
            g.DrawLine(newpen, cb, cd);
            g.DrawString("X", new Font("Arial", 10), abrush, cb);
            cb.X = 0;
            cb.Y = ydis / 2;
            cd.X = 0;
            cd.Y = -(ydis / 2);
            ConverttoScreen(ref cb);
            ConverttoScreen(ref cd);
            g.DrawLine(newpen, cb, cd);
            g.DrawString("Y", new Font("Arial", 10), abrush, cb);

        }
        public void addNode(ref Array s, Array p)
        {
            Array c;
            c = s;
            if (c != null)
            {
                while (c.next != null && c != null)
                {
                    c = c.next;
                }
            }

            if (c == null)
            {
                s = p;
            }
            else
            {
                c.next = p;
            }


        }
        public void ConverttoScreen(ref PointF p)
        {
            float x, y;
            x = p.X;
            y = p.Y;
            float temp = xdis;
            temp = xlim / temp;
            float incr = 1;
            incr = incr / temp;
            x = x - (-(xdis/2));
            x = x / incr;
            temp = ydis;
            temp = ylim / temp;
            incr = 1;
            incr = incr / temp;
            y = y - (-(ydis/2));
            y = y / incr;
            y = ylim - y;
            p.X = x;
            p.Y = y;
        }
        public void DrawCurve(Array x, Array y, ref Graphics g)
        {
            Color setColor = Color.FromArgb(0,0,255);
            SolidBrush a = new SolidBrush(setColor);
            Pen b = new Pen(a);
            PointF p1 = new PointF(), p2=new PointF();
            while(x.next!=null)
            {
                p1.X = x.value;
                p1.Y = y.value;
                x = x.next;
                y = y.next;
                p2.X = x.value;
                p2.Y = y.value;
                ConverttoScreen(ref p1);
                ConverttoScreen(ref p2);
                g.DrawLine(b,p1, p2);
            }

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            xlim = pictureBox1.Width;
            ylim = pictureBox1.Height;
            Array startx = new Array(), starty=new Array();
            CreateArrayX(ref startx);
            Array x = startx;
            Array y = starty;
            while(x != null)
            {
                GetY(x, ref y);
                Array tempx = new Array();
                tempx = x.next;
                x = new Array();
                x = tempx;
                Array tempy = new Array();
                y.next = tempy;
                y = new Array();
                y = tempy;

            }
            DrawCurve(startx, starty, ref g);
            CreateAxis(ref g);


        }
    }
}
