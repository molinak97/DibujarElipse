using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Elipse
{
    public partial class Form1 : Form
    {
        int p = 0;//contador puntos
        int X1 = 0;
        int Y1 = 0;
        int X2 = 0;
        int Y2 = 0;
        int Xc = 0;
        int Yc = 0;
        int Rx = 0;
        int Ry = 0;
        Pen pen = new Pen(Color.Green, 3);//ALN
        Pen pen1 = new Pen(Color.Red, 3);//MDP
        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
            label4.Text = "";
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            p++;
            int x, y;
            x = e.X;
            y = e.Y;
            panel1.CreateGraphics().DrawEllipse(pen, x, y, 5, 5);
            if (p - 1 == 0)
            {
                X1 = x;
                Y1 = y;
            }
            else if (p - 2 == 0)
            {
                X2 = x;
                Y2 = y;
                CCentro(X1, Y1, X2, Y2);
                CRadios(X1, Y1, X2, Y2);
                CPuntos(X1, Y1, X2, Y2);
                ElipseALN(X1, Y1, X2, Y2);
                /*ElipseMDP(X1, Y1, X2, Y2);*/
                p = 0;
            }
        }
        private void CCentro(int X1, int Y1, int X2, int Y2)
        {
            if(X1 > X2)
            {
                if(Y1 > Y2)
                {
                    Xc = X2;
                    Yc = Y1;
                    panel1.CreateGraphics().DrawEllipse(pen1,Xc,Yc, 5, 5);
                }
                else
                {
                    Xc = X1;
                    Yc = Y2;
                    panel1.CreateGraphics().DrawEllipse(pen1, Xc, Yc, 5, 5);
                }
            }
            else
            {
                if(Y1 < Y2)
                {
                    Xc = X1;
                    Yc = Y2;
                    panel1.CreateGraphics().DrawEllipse(pen1, Xc, Yc, 5, 5);
                }
                else
                {
                    Xc = X2;
                    Yc = Y1;
                    panel1.CreateGraphics().DrawEllipse(pen1, Xc, Yc, 5, 5);
                }           
            }
        }
        private void CRadios(int X1, int Y1, int X2, int Y2)
        {
            if(X1 == Xc)//verificar cual radios sera RadioY
            {
                Ry = Yc - Y1;
                if(X2 < Xc)
                {
                    Rx = Xc - X2;
                }
                else
                {
                    Rx = X2 - Xc;
                }
            }
            else//RadioX
            {
                Ry = Yc - Y2;
                if (X2 < Xc)
                {
                    Rx = Xc - X2;
                }
                else
                {
                    Rx = X2 - Xc;
                }
            }

        }
        private void CPuntos(int X1, int Y1, int X2, int Y2)
        {
            int auxX = 0;
            int auxY = 0;
            if (Y1 == Yc)
            {
                MessageBox.Show("X1-"+ X1 + "Y1-"+ Y1);
                MessageBox.Show("X2-" + X2 + "Y2-" + Y2);
                auxX = X2;
                auxY = Y2;
                X2 = X1;
                Y2 = Y1;
                X1 = auxX;
                Y1 = auxY;
                MessageBox.Show("en Y");
                MessageBox.Show("X1-" + X1 + "Y1-" + Y1);
                MessageBox.Show("X2-" + X2 + "Y2-" + Y2);
            }
            else
            {
                //ElipseALN(X1, Y1, X2, Y2);
            }

        }
        private void ElipseALN(int X1, int Y1, int X2, int Y2)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double xd=2, yd=2;
            int x;
            int y;
                for (x = 0; x <= Rx; x++)
                {
                    yd = Math.Sqrt((((Math.Pow(Rx, 2)) * (Math.Pow(Ry, 2))) - ((Math.Pow(x, 2)) * (Math.Pow(Ry, 2)))) / Math.Pow(Rx, 2));
                    panel1.CreateGraphics().DrawEllipse(pen, x + Xc, -(int)yd + Yc, 5, 5);
                }
            label3.Text = String.Format("{0}", sw.Elapsed.TotalMilliseconds);
        }
        private void ElipseMDP(int X1, int Y1, int X2, int Y2)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();



            label3.Text = String.Format("{0}", sw.Elapsed.TotalMilliseconds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }
    }
}
