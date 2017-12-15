using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        public float[] ep = new float[3] { 0, 0, 1 };
        public float[] c = new float[3] { -1, -1, 0 };
        public double[] deg = new double[3];
        public float[] s = new float[3] { 180, 180, 180 };
        public float[] refp = new float[3];
        
        
        //public int vset = 0;
        public void DPerspective(float[] c, float[] s, ref float x, ref float y, ref float z) //0=x 1=y 2=z
        {
            s[0] = (float)(s[0] * Math.PI) / 180;
            s[1] = (float)(s[1] * Math.PI) / 180;
            s[2] = (float)(s[2] * Math.PI) / 180;
            float d = 0;
            float xt, yt, zt;

            d = ((float)Math.Sin(s[2]) * (y - c[1])) + ((float)Math.Cos(s[2]) * (x - c[0]));
            d = d * (float)Math.Cos(s[1]);
            d = d - ((float)Math.Sin(s[1]) * (z - c[2]));
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
            bx = bx - (e[0]);

            by = e[2] / dz;
            by = by * dy;
            by = by - (e[1]);

        }
        public void Rotation3D(string xyz, ref float x, ref float y, ref float z, double angle, float[] refpoint)
        {
            angle = angle * (Math.PI / 180);
            double yt, xt, zt;
            x = x - refpoint[0];
            y = y - refpoint[1];
            z = z - refpoint[2];

            if (xyz == "x")
            {
                yt = (y * Math.Cos(angle)) - (z * Math.Sin(angle));
                zt = (y * Math.Sin(angle)) + (z * Math.Cos(angle));
                xt = x;
                y = (float)yt+refpoint[1];
                z = (float)zt+refpoint[2];
                x = (float)xt+refpoint[0];
            }
            else if (xyz == "y")
            {
                zt = (z * Math.Cos(angle)) - (x * Math.Sin(angle));
                xt = (z * Math.Sin(angle)) + (x * Math.Cos(angle));
                yt = y;
                y = (float)yt + refpoint[1];
                z = (float)zt + refpoint[2];
                x = (float)xt + refpoint[0];
            }
            else if (xyz == "z")
            {
                xt = (x * Math.Cos(angle)) - (y * Math.Sin(angle));
                yt = (x * Math.Sin(angle)) + (y * Math.Cos(angle));
                zt = z;
                y = (float)yt + refpoint[1];
                z = (float)zt + refpoint[2];
                x = (float)xt + refpoint[0];
            }
           
        }
        public void GetNacaPoints(ref float[,] nacapointsu, ref float[,] nacapointsc, ref float[,] nacapointsl,int nacanum, float clength)
        {
            int naca, thick, camb, cambd, front;
            float mask;
            double p = 0.0;
            double t = 0.0;
            double m = 0.0;
            naca = nacanum;

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
                xl2 = (int)(clength * xl[i]);
                yl2 = 200 - (int)(clength * yl[i]);
                //g.DrawLine(System.Drawing.Pens.Red, xl1, yl1, xl2, yl2);
                xl1 = xl2;
                yl1 = yl2;

                xu2 = (int)(clength * xu[i]);
                yu2 = 200 - (int)(clength * yu[i]);
                //g.DrawLine(System.Drawing.Pens.Red, xu1, yu1, xu2, yu2);
                xu1 = xu2;
                yu1 = yu2;

                xc2 = (int)(clength/100) * i;
                yc2 = 200 - (int)(clength * yc[i]);
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
           // CordLength(ref nacapointsu, 51);
           // CordLength(ref nacapointsc, 51);
           // CordLength(ref nacapointsl, 51);
            r = (float)(1.1019 * t * t);
        }
        public void ConvertScreen(string c,ref float x, ref float y)
        {
            
            int width = this.Width;
            int height = this.Height;
            float g = width / 4;
            float h = height / 4;
            g = (float)1 / g; // ratio of user to a pixel 
            h = (float)1 / h;
            if(c == "u")
            {
                x = x * g;
                x = (-2) + x;
                y = y * h;
                y = (-2) + y;
            }
            if(c == "s")
            {
                x = x - (-2);
                x = x / g;
                y = y - (-2);
                y = y / h;
            }

        }
        public void GraphThing(float[] c, float[] s, float[,] nacapointsu, float[,] nacapointsc, float[,] nacapointsl, ref Graphics g, int n)
        {
            Color setcolor = Color.FromArgb(255, 0, 0);//FromArgb(43, 62, 128);
            SolidBrush me = new SolidBrush(setcolor);
            Pen pl = new Pen(me);
            Color pewee = Color.FromArgb(0, 0, 255);
            me= new SolidBrush(pewee);
            Pen cvb = new Pen(me);
            pewee = Color.FromArgb(0, 255, 0);
            me = new SolidBrush(pewee);
            Pen gre = new Pen(me);
            int width = this.Width / 2;
            int height = this.Height / 2;
            float dx, dy, dz;
            PointF[,] zu = new PointF[51, 51];
            PointF[,] zc = new PointF[51, 51];
            PointF[,] zl = new PointF[51, 51];
            PointF[,,] All = new PointF[3, 51, 51];
            float bnm = ep[2];
            int pbn = 5;
            
            for (int b = 0; b < pbn; b++)
            {
                float[,] t1 = nacapointsu;
                float[,] t2 = nacapointsc;
                float[,] t3 = nacapointsl;    
                          
                float z = b +(float)0.5 ;
                PointF[] p = new PointF[n];
                float clene = int.Parse(textBox1.Text)-(b*(int.Parse(textBox1.Text)/pbn));
                GetNacaPoints(ref t1, ref t2, ref t3, int.Parse(comboBox1.Text), clene);
                //CordLength(ref t1, n);
                for (int i = 0; i < n; i++)
                {
                    ConvertScreen("u", ref t1[i, 0], ref t1[i, 1]);
                    float bx = 0, by = 0;
                    dx = t1[i, 0];
                    dy = t1[i, 1];
                    dz = z;
                    Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0],refp);
                    Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1],refp);
                    Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2],refp);
                    DPerspective(c, s, ref dx, ref dy, ref dz);
                    BPerspective(dx, dy, dz, ref bx, ref by, ep);
                    ConvertScreen("s", ref bx, ref by);
                    p[i].X = bx;// +width;
                    p[i].Y = by;// +height;
                    All[0, b, i].X = bx;
                    All[0, b, i].Y = by;                                   
                }
                
                g.DrawCurve(gre, p);
                GetNacaPoints(ref t1, ref t2, ref t3, int.Parse(comboBox1.Text), clene);
                //CordLength(ref t2, n);
                for (int i = 0; i < n; i++)
                {
                    ConvertScreen("u", ref t2[i, 0], ref t2[i, 1]);
                    float bx = 0, by = 0;
                    dx = t2[i, 0];
                    dy = t2[i, 1];
                    dz = z;
                    Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0],refp);
                    Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1],refp);
                    Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2],refp);
                    DPerspective(c, s, ref dx, ref dy, ref dz);
                    BPerspective(dx, dy, dz, ref bx, ref by, ep);
                    ConvertScreen("s", ref bx, ref by);
                    p[i].X = bx;// +width;
                    p[i].Y = by;// +height;
                    //g.DrawRectangle(pl, bx + width, by + height, 10, 10);
                    All[1, b, i].X = bx;
                    All[1, b, i].Y = by;

                }
                g.DrawCurve(pl, p);
                float[] cp = new float[3] { t2[0, 0]-(float)1, t2[0, 1], z };
                float[] cpz = new float[3] { t2[0, 0], t2[0, 1], z };
                
                AngleAt(ref cp[0], ref cp[1], ref cp[2], cpz, float.Parse(textBox6.Text), ref g, cvb, (int)All[1, b, 0].X, All[1, b, 1].Y);
                GetNacaPoints(ref t1, ref t2, ref t3, int.Parse(comboBox1.Text), clene);
                
                for (int i = 0; i < n; i++)
                {
                    ConvertScreen("u", ref t3[i, 0], ref t3[i, 1]);
                    float bx = 0, by = 0;
                    dx = t3[i, 0];
                    dy = t3[i, 1];
                    dz = z;
                    Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0],refp);
                    Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1],refp);
                    Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2],refp);
                    DPerspective(c, s, ref dx, ref dy, ref dz);
                    BPerspective(dx, dy, dz, ref bx, ref by, ep);
                    ConvertScreen("s", ref bx, ref by);
                    p[i].X = bx;// +width;
                    p[i].Y = by;// +height;
                    //g.DrawRectangle(pl, bx + width, by + height, 10, 10);
                    All[2, b, i].X = bx;
                    All[2, b, i].Y = by;
                }
                g.DrawCurve(gre, p);
                /*ep[2] = ep[2] - (float)0.05;
                if(ep[2]<0)
                {
                    ep[2] = 0;
                }*/
            }
            ep[2] = bnm;
            PointF[] pc = new PointF[pbn];
            for (int z = 0; z < n; z++)
            {
                for (int i = 0; i < pbn; i++)
                {
                    pc[i].X = All[0,i,z].X;
                    pc[i].Y = All[0,i,z].Y;
                }
                for (int i = 0; i < pbn - 1; i++)
                {
                    PointF[] temp = new PointF[2] { pc[i], pc[i + 1] };
                    g.DrawCurve(pl, temp);
                }
                for (int i = 0; i < pbn; i++)
                {
                    pc[i].X = All[2, i, z].X;
                    pc[i].Y = All[2, i, z].Y;
                }
                for (int i = 0; i < pbn - 1; i++)
                {
                    g.DrawLine(pl, pc[i], pc[i + 1]);
                }

            }



            for (int b = 0; b < pbn; b++)
            {
                float[,] t1 = nacapointsu;
                float[,] t2 = nacapointsc;
                float[,] t3 = nacapointsl;

                float z = -b-(float)0.5;
                PointF[] p = new PointF[n];
                float clene = int.Parse(textBox1.Text) - (b * (int.Parse(textBox1.Text) / pbn));
                GetNacaPoints(ref t1, ref t2, ref t3, int.Parse(comboBox1.Text), clene);
                for (int i = 0; i < n; i++)
                {
                    ConvertScreen("u", ref t1[i, 0], ref t1[i, 1]);
                    float bx = 0, by = 0;
                    dx = t1[i, 0];
                    dy = t1[i, 1];
                    dz = z;
                    Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0], refp);
                    Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1], refp);
                    Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2], refp);
                    DPerspective(c, s, ref dx, ref dy, ref dz);
                    BPerspective(dx, dy, dz, ref bx, ref by, ep);
                    ConvertScreen("s", ref bx, ref by);
                    p[i].X = bx;// +width;
                    p[i].Y = by;// +height;
                    All[0, b, i].X = bx;
                    All[0, b, i].Y = by;
                }
                g.DrawCurve(gre, p);
                GetNacaPoints(ref t1, ref t2, ref t3, int.Parse(comboBox1.Text), clene);
                for (int i = 0; i < n; i++)
                {
                    ConvertScreen("u", ref t2[i, 0], ref t2[i, 1]);
                    float bx = 0, by = 0;
                    dx = t2[i, 0];
                    dy = t2[i, 1];
                    dz = z;
                    Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0], refp);
                    Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1], refp);
                    Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2], refp);
                    DPerspective(c, s, ref dx, ref dy, ref dz);
                    BPerspective(dx, dy, dz, ref bx, ref by, ep);
                    ConvertScreen("s", ref bx, ref by);
                    p[i].X = bx;// +width;
                    p[i].Y = by;// +height;
                    //g.DrawRectangle(pl, bx + width, by + height, 10, 10);
                    All[1, b, i].X = bx;
                    All[1, b, i].Y = by;

                }

                
                g.DrawCurve(pl, p);
                float[] cp = new float[3] { t2[0, 0] - (float)1, t2[0, 1], z };
                float[] cpz = new float[3] { t2[0, 0], t2[0, 1], z };

                AngleAt(ref cp[0], ref cp[1], ref cp[2], cpz, float.Parse(textBox6.Text), ref g, cvb, (int)All[1, b, 0].X, All[1, b, 1].Y);
                
                GetNacaPoints(ref t1, ref t2, ref t3, int.Parse(comboBox1.Text), clene);
                for (int i = 0; i < n; i++)
                {
                    ConvertScreen("u", ref t3[i, 0], ref t3[i, 1]);
                    float bx = 0, by = 0;
                    dx = t3[i, 0];
                    dy = t3[i, 1];
                    dz = z;
                    Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0], refp);
                    Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1], refp);
                    Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2], refp);
                    DPerspective(c, s, ref dx, ref dy, ref dz);
                    BPerspective(dx, dy, dz, ref bx, ref by, ep);
                    ConvertScreen("s", ref bx, ref by);
                    p[i].X = bx;// +width;
                    p[i].Y = by;// +height;
                    //g.DrawRectangle(pl, bx + width, by + height, 10, 10);
                    All[2, b, i].X = bx;
                    All[2, b, i].Y = by;
                }
                g.DrawCurve(gre, p);
                
            }
            //ep[2] = bnm;
            for (int z = 0; z < n; z++)
            {
                for (int i = 0; i < pbn; i++)
                {
                    pc[i].X = All[0, i, z].X;
                    pc[i].Y = All[0, i, z].Y;
                }
                for (int i = 0; i < pbn - 1; i++)
                {
                    g.DrawLine(pl, pc[i], pc[i + 1]);
                }
                for (int i = 0; i < pbn; i++)
                {
                    pc[i].X = All[2, i, z].X;
                    pc[i].Y = All[2, i, z].Y;
                }
                for (int i = 0; i < pbn - 1; i++)
                {
                    g.DrawLine(pl, pc[i], pc[i + 1]);
                }

            }
            float anglep = 30;
           // AngleAttack(All, n, ref g,pl,anglep);



        }
		public void CordLength(ref float[,] A1,int n)
		{
            float change;
            change = A1[n - 1, 0] - A1[0, 0];
            change = int.Parse(textBox1.Text) - change;
            float x = change / 2;
            float y = change;
            A1[0, 0] = A1[0, 0] - change;
            for (int i = 1; i<n-1;i++)
            {
                if (A1[i, 1] > A1[0, 1])
                {
                    A1[i, 0] = A1[i, 0] - x;
                    A1[i, 1] = A1[i, 1] + y;
                }
                if (A1[i, 1] < A1[0, 1])
                {
                    A1[i, 0] = A1[i, 0] - x;
                    A1[i, 1] = A1[i, 1] - y;
                }


            } 
            
		}
        public void AngleAt(ref float dx, ref float dy, ref float dz, float[] cnm, float angle, ref Graphics g, Pen pl, float zx, float zy ) // Set 
		{
            angle = -angle;
			float bx = 0;
			float by = 0;
            //float[] refpi = new Float[3] {point.X,point.Y,z};
            //angle = angle*(float)(Math.PI/180);
            Rotation3D("z", ref dx, ref dy, ref dz, (double)angle, cnm);
            Rotation3D("x", ref dx, ref dy, ref dz, (double)deg[0], refp);
			Rotation3D("y", ref dx, ref dy, ref dz, (double)deg[1], refp);
			Rotation3D("z", ref dx, ref dy, ref dz, (double)deg[2], refp);			
			DPerspective(c,s,ref dx, ref dy, ref dz);
			BPerspective(dx,dy,dz, ref bx, ref by,ep);
            ConvertScreen("s", ref bx, ref by);
			PointF p = new PointF(bx,by);
			
			PointF p1 = new PointF(zx,zy);
			g.DrawLine(pl,p,p1);
		}
        public void AngleAttack(PointF[,,] nc, int n, ref Graphics g, Pen pl, float angle)
        {
            PointF a=new PointF(), b = new PointF();
            
            float[] nm = new float[2];
            
            nm[0] = nc[1, 0, 0].X;
            nm[1]= nc[1, 0, 0].Y;
            //ConvertScreen("s", ref nm[0], ref nm[1]);
            a.X = nm[0];
            a.Y = nm[1];
            nm[0] = nc[1, 0,n-1].X;
            nm[1] = nc[0,0,n-1].Y;
            //ConvertScreen("s", ref nm[0], ref nm[1]);
            b.X = nm[0];
            b.Y = nm[1];

            float m = b.Y - a.Y;
            m = m / (b.X - a.X);
            float yint = a.X * m;
            yint = a.Y - yint;
            PointF referp = new PointF(a.X, a.Y);
            PointF attack = new PointF();
            attack.X = a.X - 50;
            attack.Y = a.X * m;
            attack.Y = attack.Y + yint;
            attack.X = attack.X - referp.X;
            attack.Y = attack.Y - referp.Y;
            angle = angle * ((float)Math.PI / 180);
            float ax, by;
            ax = attack.X * (float)(Math.Cos(angle));
            ax = ax - (attack.Y * (float)Math.Sin(angle));
            by = attack.X * (float)Math.Sin(angle);
            by = by + attack.Y * (float)Math.Cos(angle);
            attack.X = ax + referp.X;
            attack.Y = by + referp.Y;
            g.DrawLine(pl, attack, a);


        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.A)
            {
                c[0] = c[0] + (float)0.5;
                pictureBox1.Invalidate();

                //if(c[0]<-360 || c[0]>360)
                //{
                //    c[0] = 0;
                //}
            }
            if (e.KeyCode == Keys.D)
            {
                c[0] = c[0] - (float)0.5;
                pictureBox1.Invalidate();
                //if (c[0] < -360 || c[0] > 360)
                //{
                //    c[0] = 0;
                //}
            }
            if (e.KeyCode == Keys.W)
            {
                c[1] = c[1] + (float)0.5;
                pictureBox1.Invalidate();
                //if (c[1] < -360 || c[1] > 360)
                //{
                //    c[1] = 0;
                //}
            }
            if (e.KeyCode == Keys.S)
            {
                c[1] = c[1] - (float)0.5;
                pictureBox1.Invalidate();
                //if (c[1] < -360 || c[1] > 360)
                //{
                //    c[1] = 0;
                //}
            }
            if (e.KeyCode == Keys.Z)
            {
                ep[2] = ep[2] + (float)0.05;
                pictureBox1.Invalidate();
                //c[2] = c[2] - (float)0.05;
                //if (c[2] < -360 || c[2] > 360)
                //{
                //    c[2] = 0;
                //}
            }
            if (e.KeyCode == Keys.C)
            {
                ep[2] = ep[2] - (float)0.05;
                pictureBox1.Invalidate();
                //c[2] = c[2] + (float)0.05;
                //if (c[2] < -360 || c[2] > 360)
                //{
                //    c[2] = 0;
                //}
            }
            if (e.KeyCode == Keys.I)
            {
                deg[0] = deg[0] + (float)1;
            }
            if (e.KeyCode == Keys.K)
            {
                deg[0] = deg[0] - (float)1;
            }
            if (e.KeyCode == Keys.J)
            {
                deg[1] = deg[1] + (float)1;
            }
            if (e.KeyCode == Keys.L)
            {
                deg[1] = deg[1] - (float)1;
            }
            if (e.KeyCode == Keys.N)
            {
                deg[2] = deg[2] + (float)1;
            }
            if (e.KeyCode == Keys.M)
            {
                deg[2] = deg[2] - (float)1;
            }




        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            comboBox1.Select(0, 0);
            Graphics g = e.Graphics;
            int vset = Int32.Parse(comboBox1.Text);
            float[,] nacapointsu = new float[51, 2];
            float[,] nacapointsc = new float[51, 2];
            float[,] nacapointsl = new float[51, 2];
            //PointF

            deg[0] = int.Parse(textBox2.Text);
            deg[1] = int.Parse(textBox3.Text);
            deg[2] = int.Parse(textBox4.Text);
            ep[2] = float.Parse(textBox5.Text);
            float clength;
            clength = nacapointsc[50, 0] - nacapointsc[0, 0];
            float cheg = int.Parse(textBox1.Text);
            GetNacaPoints(ref nacapointsu, ref nacapointsc, ref nacapointsl, vset, cheg);
            //CordLength(ref nacapointsu, 51, cheg);
            refp = new float[3] { 0, 0, 0 };
            //ConvertScreen("u", ref refp[0], ref refp[1]);
            for(int i = 0;i<51;i++)
            {
                float x = nacapointsu[i, 0];
                float y = nacapointsu[i, 1];
                ConvertScreen("u", ref x, ref y);
                nacapointsu[i, 0] = x;
                nacapointsu[i, 1] = y;

                x = nacapointsc[i, 0];
                y = nacapointsc[i, 1];
                ConvertScreen("u", ref x, ref y);
                nacapointsc[i, 0] = x;
                nacapointsc[i, 1] = y;

                x = nacapointsl[i, 0];
                y = nacapointsl[i, 1];
                ConvertScreen("u", ref x, ref y);
                nacapointsl[i, 0] = x;
                nacapointsl[i, 1] = y;
                
            }
            GraphThing(c, s, nacapointsu, nacapointsc, nacapointsl, ref g, 51);
            
            //pictureBox1.Invalidate();
            
            
            
        }
           
                
        private void Form1_Click(object sender, EventArgs e)
        {
            comboBox1.Select(0, 0);
            pictureBox1.Invalidate();
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Select();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}
