using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3Dstuff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public float x = 0;
        public float y = 0;
        public float z = 0;
        public float[] c = new float[3] { 0, 0, 0 };
        public double[] deg = new double[3];
        public float[] s = new float[3] { 180, 180, 200 };
       

        public void DPerspective(float[] c, float[] s, ref float x, ref float y, ref float z) //0=x 1=y 2=z
        {
            s[0] = (float)(s[0] * Math.PI) / 180;
            s[1] = (float)(s[1] * Math.PI) / 180;
            s[2] = (float)(s[2] * Math.PI) / 180;
            float d = 0;
            float xt, yt, zt;
            
                d = ((float)Math.Sin(s[2]) * (y-c[1])) + ((float)Math.Cos(s[2]) * (x-c[0]));
                d = d * (float)Math.Cos(s[1]);
                d = d - ((float)Math.Sin(s[1]) * (z-c[2]));
                xt = d;
            
            
                d = ((float)Math.Sin(s[2]) * (y - c[1])) + ((float)Math.Cos(s[2]) * (x - c[0]));
                d = d * (float)Math.Sin(s[1]);
                d = ((float)Math.Cos(s[1]) * (z - c[2])) + d;
                d = d * (float)Math.Sin(s[0]);
                d = d + ((float)Math.Cos(s[0]) * (((float)Math.Cos(s[2]) * (y - c[1])) - ((float)Math.Sin(s[2]) * (x - c[0]))));
                yt = d;
            
           
                d = ((float)Math.Sin(s[2]) * (y - c[1])) + ((float)Math.Cos(s[2]) * (x - c[0]));
                d = d * (float)Math.Sin(s[1]);
                d = ((float)Math.Cos(s[1]) * (z - c[2])) + d;
                d = (float)Math.Cos(s[0]);
                d = d - ((float)Math.Sin(s[0]) * (((float)Math.Cos(s[2]) * (y - c[1])) - ((float)Math.Sin(s[2]) * (x - c[0]))));
                zt = d;

            x = xt;
            y = yt;
            z = zt;
            
        }

        public void BPerspective(float dx, float dy, float dz, ref float bx, ref float by, float[] e)
        {
            bx = e[2] / dz;
            bx = bx * dx;
            bx = bx - e[0];
            by = e[2] / dz;
            by = by * dy;
            by = by - e[1];
        }
        public void Rotation3D(string xyz, ref float x, ref float y, ref float z, double angle)
        {
            angle = angle * (Math.PI / 180);
            double yt,xt,zt;
            
            if (xyz == "x")
            {
                yt = (y * Math.Cos(angle)) - (z * Math.Sin(angle));
                zt = (y * Math.Sin(angle)) - (z * Math.Cos(angle));
                xt = x;
                y = (float)yt;
                z = (float)zt;
                x = (float)xt;
            }
            else if(xyz == "y")
            {
                zt = (z * Math.Cos(angle)) - (x * Math.Sin(angle));
                xt = (z * Math.Sin(angle)) + (x * Math.Cos(angle));
                yt = y;
                y = (float)yt;
                z = (float)zt;
                x = (float)xt;
            }
            else if(xyz == "z")
            {
                xt = (x * Math.Cos(angle)) - (y * Math.Sin(angle));
                yt = (x * Math.Sin(angle)) + (y * Math.Cos(angle));
                zt = z;
                x = (float)xt;
                y = (float)yt;
                z = (float)zt;
            }
        }
        public void GetNacaPoints(ref float[,] nacapointsu, ref float[,] nacapointsc, ref float[,] nacapointsl)
        {
            int naca, thick, camb, cambd, front;
            float mask;
            double p = 0.0;
            double t = 0.0;
            double m = 0.0;
            naca = 2412;

            mask = (float)naca;
            mask = (float)(mask / 100.0);
            front = naca / 100;
            mask = (float)((mask - front) * 100.0 + 0.001);
            thick = (int)mask;
            //MT.Text = thick.ToString() + " %";
            mask = (float)front;
            camb = front / 10;
            //MXC.Text = camb.ToString() + " %";
            mask = (float)(mask / 10.0);
            mask = (float)((mask - camb) * 10.0);
            cambd = (int)(mask + 0.01);
            t = (float)(thick / 100.0);
            //DtMc.Text = cambd.ToString() + "0%";
            t = (float)(thick / 100.0);//thickness
            p = (double)(cambd) / 10;//Camb distance
            m = (double)(camb) / 100.0;//camb #

            float x, c, yt, temp, ts, tt, tf, r, dycdx, theta;
            int i, xl1, yl1, xu1, yu1, yc1, xl2, yl2, xu2, yu2, yc2, xc1, xc2;
            float[] xu, xl, yu, yl, yc;
            xl = new float[101];
            yl = new float[101];
            xu = new float[101];
            yu = new float[101];
            yc = new float[101];
            c = (float)1.0;
            xl1 = 0;
            yl1 = 200;
            xu1 = 0;
            yu1 = 200;
            yc1 = 200;
            xc1 = 0;

            for (i = 0; i <= 100; i = i + 2)
            {

                x = i;
                x = x / (float)100.0;
                temp = x / c;
                ts = temp * temp;
                tt = ts * temp;
                tf = tt * temp;
                yt = (float)(5.0 * t * c * (0.2969 * Math.Sqrt(temp) - 0.1260 * (temp) - 0.3516 * ts + 0.2843 * tt - 0.1015 * tf));
                //cout << " x = " << x << "  yt= " << yt << "\n";
                if (p < 0.00001)
                {
                    yc[i] = (float)0.0;
                    dycdx = (float)0.0;
                    theta = (float)0.0;
                }
                else
                {
                    if (x <= p * c)
                    {
                        yc[i] = (float)(m * (x / (p * p)) * (2.0 * p - x / c));
                        dycdx = (float)((2.0 * m) / (p * p) * (p - x / c));
                    }
                    else
                    {
                        yc[i] = (float)(m * (c - x) / ((1 - p) * (1 - p)) * (1.0 + x / c - 2.0 * p));
                        dycdx = (float)((2.0 * m) / ((1 - p) * (1 - p)) * (p - x / c));
                    }
                    theta = (float)Math.Atan(dycdx);
                }
                xl[i] = (float)(x + yt * Math.Sin(theta));
                yl[i] = (float)(yc[i] - yt * Math.Cos(theta));
                xu[i] = (float)(x - yt * Math.Sin(theta));
                yu[i] = (float)(yc[i] + yt * Math.Cos(theta));
                xl2 = (int)(800 * xl[i]);
                yl2 = 200 - (int)(800 * yl[i]);
                //g.DrawLine(System.Drawing.Pens.Red, xl1, yl1, xl2, yl2);
                xl1 = xl2;
                yl1 = yl2;

                xu2 = (int)(800 * xu[i]);
                yu2 = 200 - (int)(800 * yu[i]);
                //g.DrawLine(System.Drawing.Pens.Red, xu1, yu1, xu2, yu2);
                xu1 = xu2;
                yu1 = yu2;

                xc2 = 8 * i;
                yc2 = 200 - (int)(800 * yc[i]);
                //g.DrawLine(System.Drawing.Pens.Blue, xc1, yc1, xc2, yc2);
                xc1 = xc2;
                yc1 = yc2;
                //  cout << " xl= " << xl << "  yl= " << yl << "  xu= " << xu << "  yu=" << yu << "\n";
                //listBox1.Items.Add("XL[" + i + "]=   " + xl[i] + "    YL[" + i + "]=     " + yl[i] + "     XU[" + i + "]=" + xu[i] + "    YU[" + i + "]=  " + yu[i] + "  YC[" + i + "]= " + yc[i]);
                int s = i / 2;
                nacapointsu[s, 0] = xu1;
                nacapointsu[s, 1] = yu1;
                nacapointsc[s, 0] = xc1;
                nacapointsc[s, 1] = yc1;
                nacapointsl[s, 0] = xl1;
                nacapointsl[s, 1] = yl1; 
            }
            r = (float)(1.1019 * t * t);
        }
        float[] ep = new float[3] { 0, 0, 1 };
        public void GraphThing(float[] c,float[] s, float[,] nacapointsu, float[,] nacapointsc, float[,] nacapointsl, ref Graphics g, int n)
        {
            Color setcolor = Color.FromArgb(255, 0, 0);//FromArgb(43, 62, 128);
            SolidBrush me = new SolidBrush(setcolor);
            Pen pl = new Pen(me);
            int width = pictureBox1.Width / 2;
            int height = pictureBox1.Height / 2;
            float dx, dy, dz;
            PointF[,] zu = new PointF[51,51];
            PointF[,] zc = new PointF[51,51];
            PointF[,] zl = new PointF[51,51];

            for (int b = 0;b<50;b++)
            {
                z = b * 4;
                PointF[] p = new PointF[n];
                for(int i = 0; i<n;i++)
                {
                    
                    float bx=0, by=0;
                    dx = nacapointsu[i, 0];
                    dy = nacapointsu[i, 1];
                    dz = z;
                    Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0]);
                    Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1]);
                    Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2]);
                    DPerspective(c, s, ref dx, ref dy, ref dz);
                    BPerspective(dx, dy, dz, ref bx, ref by, ep);

                    p[i].X = bx;// +width;
                    p[i].Y = by;// +height;
                    //g.DrawRectangle(pl, bx + width, by + height, 10, 10);
                    /*dx = nacapointsu[i, 0];
                    dy = nacapointsu[i, 1];
                    dz = b;
                    Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0]);
                    Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1]);
                    Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2]);
                    DPerspective(c, s, ref dz, ref dy, ref dx);
                    BPerspective(dx, dy, dz, ref bx, ref by, ep);*/
                    zu[b, i].X = bx;
                    zu[b, i].Y = by;
                }
                g.DrawCurve(pl, p);
                for (int j = 0; j < n; j++)
                {
                    
                    float bx = 0, by = 0;
                    dx = nacapointsc[j, 0];
                    dy = nacapointsc[j, 1];
                    dz = z;
                    Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0]);
                    Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1]);
                    Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2]);
                    DPerspective(c, s, ref dx, ref dy, ref dz);
                    BPerspective(dx, dy, dz, ref bx, ref by, ep);

                    p[j].X = bx;// +width;
                    p[j].Y = by;// +height;
                    //g.DrawRectangle(pl, bx + width, by + height, 10, 10);
                }
                g.DrawCurve(pl, p);
                for (int i = 0; i < n; i++)
                {
                    
                    float bx = 0, by = 0;
                    dx = nacapointsl[i, 0];
                    dy = nacapointsl[i, 1];
                    dz = z;
                    Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0]);
                    Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1]);
                    Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2]);
                    DPerspective(c, s, ref dx, ref dy, ref dz);
                    BPerspective(dx, dy, dz, ref bx, ref by, ep);

                    p[i].X = bx;// +width;
                    p[i].Y = by;// +height;
                    //g.DrawRectangle(pl, bx + width, by + height, 10, 10);
                }
                g.DrawCurve(pl, p);

            }
            PointF[] pc = new PointF[n];
            for(int z =0;z<n;z++)
            {
                for (int i = 0; i < n; i++)
                {
                    pc[i].X = zu[z, i].X;
                    pc[i].Y = zu[z, i].Y;
                }
                g.DrawCurve(pl, pc);
            }
            
            
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            float[,] nacapointsu = new float[51, 2];
            float[,] nacapointsc = new float[51, 2];
            float[,] nacapointsl = new float[51, 2];
            this.KeyPreview = true;
            
            GetNacaPoints(ref nacapointsu, ref nacapointsc, ref nacapointsl);
            Graphics g = e.Graphics;
            GraphThing(c, s, nacapointsu, nacapointsc, nacapointsl, ref g, 51);
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c[0] = 0; //x
            c[1] = 0; //y
            c[2] = 0; //z

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.A)
                {
                    c[0] = c[0] + 4;

                    //if(c[0]<-360 || c[0]>360)
                    //{
                    //    c[0] = 0;
                    //}
                }
                if (e.KeyCode == Keys.D)
                {
                    c[0] = c[0] - 4;
                    //if (c[0] < -360 || c[0] > 360)
                    //{
                    //    c[0] = 0;
                    //}
                }
                if (e.KeyCode == Keys.W)
                {
                    c[1] = c[1] + 4;
                    //if (c[1] < -360 || c[1] > 360)
                    //{
                    //    c[1] = 0;
                    //}
                }
                if (e.KeyCode == Keys.S)
                {
                    c[1] = c[1] - 4;
                    //if (c[1] < -360 || c[1] > 360)
                    //{
                    //    c[1] = 0;
                    //}
                }
                if (e.KeyCode == Keys.Z)
                {
                    c[2] = c[2] + 4;
                    //if (c[2] < -360 || c[2] > 360)
                    //{
                    //    c[2] = 0;
                    //}
                }
                if(e.KeyCode == Keys.C)
                {
                    c[2] = c[2] - 4;
                    //if (c[2] < -360 || c[2] > 360)
                    //{
                    //    c[2] = 0;
                    //}
                }
                if(e.KeyCode == Keys.I)
            {
                deg[0] = deg[0] + 1;
            }
            if (e.KeyCode == Keys.K)
            {
                deg[0] = deg[0] - 1;
            }
            if (e.KeyCode == Keys.J)
            {
                deg[1] = deg[1] + 1;
            }
            if (e.KeyCode == Keys.L)
            {
                deg[1] = deg[1] - 1;
            }
            if (e.KeyCode == Keys.N)
            {
                deg[2] = deg[2] + 1;
            }
            if (e.KeyCode == Keys.M)
            {
                deg[2] = deg[2] - 1;
            }




        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color setcolor = Color.FromArgb(255, 0, 0);
            SolidBrush gh = new SolidBrush(setcolor);
            Pen b = new Pen(gh);
            float[,] test1 = new float[51,2];
            float[,] test2 = new float[51,2];
            float[,] test3 = new float[51,2];
            GetNacaPoints(ref test1, ref test2, ref test3);
            PointF[] t1 = new PointF[51];
            PointF[] t2 = new PointF[51];
            PointF[] t3 = new PointF[51];
            for (int i = 0; i<51;i++)
            {
                t1[i].X = test1[i, 0];
                t1[i].Y = test1[i, 1];
                t2[i].X = test2[i, 0];
                t2[i].Y = test2[i, 1];
                t3[i].X = test3[i, 0];
                t3[i].Y = test3[i, 1];
            }
            g.DrawCurve(b, t1);
            g.DrawCurve(b, t2);
            g.DrawCurve(b, t3);
        }
    }
}
