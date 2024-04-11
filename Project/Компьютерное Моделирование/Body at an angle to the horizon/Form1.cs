using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelirovanie
{
    public partial class Form1 : Form
    {

        const int array = 10000;
        double v0, fi, windx;
             
        double[] x = new double[array];
        double[] y = new double[array];
        double[] t = new double[array];
        double[] vmod = new double[array];

        public vect a = new vect();
        public vect v = new vect();
        public vect wind = new vect();
        public vect r = new vect(0, 0, 0);
        public vect g = new vect(0, -10, 0);

        int iter = 0;
        double dt = 0.1;
        double vmax = 10;
        

        public struct vect
        {
            public double x, y, z;
            public double modul() => Math.Sqrt(x * x + y * y + z * z);            
            public double Mod { get { return Math.Sqrt(x * x + y * y + z * z); } }     
            public vect(double x, double y, double z) { this.x = x; this.y = y; this.z = z; }
            public static vect operator +(vect a, vect b) => new vect(a.x + b.x, a.y + b.y, a.z + b.z);
            public static double operator *(vect a, vect b) => a.x * b.x + a.y * b.y; 
            public static vect operator *(double c, vect a) => new vect(a.x * c, a.y * c, a.z * c);
            public static vect operator *(vect a, double c) => new vect(a.x * c, a.y * c, a.z * c);
            public static vect operator /(vect a, double c) => new vect(a.x / c, a.y / c, a.z / c);
            public static vect operator -(vect a, vect b) => new vect(a.x - b.x, a.y - b.y, a.z - b.z);
            public static vect operator &(vect a, vect b) => new vect(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            buttonStart.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            while (vmax > 5)
            {
                vmax /= 2;
                if (vmax < 5)
                {
                    vmax = 10;
                }
            }
        }
        // Физик
        public vect accel(vect g, vect v, double vmax, vect wind, double h)
        {
            h = 0;
            return g - Math.Exp(-h / 10000) * g.Mod * (v - wind) * (v - wind).Mod / (vmax * vmax);
        }

        // Математик
        private void AlgoritmVerle(double dt, vect g, ref vect r, ref vect v, double vmax, vect wind)
        {           
            vect a = new vect();
            vect vPred = new vect();
            a = accel(g, v, vmax, wind, r.y);

            r += v * dt + 0.5 * a * dt * dt;
            vPred = v + a * dt;
            v += 0.5 * a * dt;
            a = accel(g, vPred, vmax, wind, r.y);
            v += 0.5 * a * dt;

        }
        //Художник - программист
        private void timer1_Tick(object sender, EventArgs e)
        {
            iter++;
            AlgoritmVerle(dt, g, ref r, ref v, vmax, wind);

            if ((iter >= array) || (r.y < 0))
            {
                timer1.Stop();
                return;
            }

            y[iter] = r.y;
            x[iter] = r.x;
            vmod[iter] = v.Mod;
            t[iter] = t[iter] + dt;
            chartTr.Series[0].Points.Clear();
            chartVt.Series[0].Points.Clear();

            for (int i = 0; i <= iter; i++)
            {
                chartTr.Series[0].Points.AddXY(x[i], y[i]);
                chartVt.Series[0].Points.AddXY(t[i], vmod[i]);
            }

        }

       private void buttonStart_Click(object sender, EventArgs e)
        {
            r.x = 0;
            r.y = 0;
            x[0] = 0;
            y[0] = 0;
            iter = 0;
            vmod[0] = 0;
            t[0] = 0;

            buttonStart.Enabled = false;            
            timer1.Start();

            if (!(Double.TryParse(textBoxdt.Text, out dt)))
            {
                dt = 0.1;
                textBoxdt.Text = dt.ToString();
            }

            if (!(Double.TryParse(textBoxFi.Text, out fi)))
            {
                MessageBox.Show("Угол");
                return;
            }
            fi *= Math.PI / 180;

            if (!(Double.TryParse(textBoxV0.Text, out v0)))
            {
                MessageBox.Show("Начальная Cкорость");
                return;
            }
            v.x = v0 * Math.Cos(fi);
            v.y = v0 * Math.Sin(fi);

            if(!(Double.TryParse(textBoxVmax.Text, out vmax)))
            {
                MessageBox.Show("Установившееся сокрость");
                return;
            }

            if (!(Double.TryParse(textBoxWind.Text, out windx)))
            {
                MessageBox.Show("Ветер");
            }
            wind.x = windx;

        }
    }
}
