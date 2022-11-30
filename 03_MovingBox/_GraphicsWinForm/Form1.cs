using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _GraphicsWinForm
{
    public partial class Form1 : Form
    {
        //Házi feladat: Külön projekt
        //Ezt kiegészíteni
        //Kattintásra színváltoztatás, sebességnövelés, méretcsökkentés
        //5 kattintás után nyert a játékos és kilép.
        //(kattintásra az ellenkező irányba induljon)

        //Challenge: Színátmenet

        Graphics g;

        PointF upperLeft = new PointF(50, 50);
        float size = 100;
        Brush brush = Brushes.Salmon;
        
        float velocityX = 4;
        float velocityY = 3;

        Color c1 = Color.Red;
        Color c2 = Color.Blue;

        int level = 0;

        bool Clied = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            //g.FillRectangle(brush, upperLeft.X, upperLeft.Y, size, size);

            for (int i = 0; i < size; i++)
            {
                float posx = (upperLeft.X + i) / canvas.Width;

                int R1 = (int)(c1.R * posx + c2.R * (1 - posx));
                int G1 = (int)(c1.G * posx + c2.G * (1 - posx));
                int B1 = (int)(c1.B * posx + c2.B * (1 - posx));

                Color c = Color.FromArgb(R1, G1, B1);
                g.DrawLine(new Pen(c), upperLeft.X + i, upperLeft.Y, upperLeft.X + i, upperLeft.Y + size);
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        if (e.X > upperLeft.X && e.X <= upperLeft.X + size &&
                            e.Y > upperLeft.X && e.Y <= upperLeft.Y + size && !Clied)
                        {
                            size = (int)(size * 0.9);
                            level++;
                            Clied = true;
                            velocityX = (int)(velocityX * 1.5);
                            velocityY = (int)(velocityY * 1.5);

                            Random rnd = new Random();

                            c1 = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                            c2 = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                        }
                        if (level == 5)
                        {
                            MessageBox.Show("Nyertél!");
                        }

                        
                    }
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            Clied = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            upperLeft.X += velocityX;
            upperLeft.Y += velocityY;

            if (upperLeft.Y + size > canvas.Height)
                velocityY *= -1;

            if (upperLeft.X + size > canvas.Width)
                velocityX *= -1;

            if (upperLeft.Y < 0)
                velocityY *= -1;

            if (upperLeft.X < 0)
                velocityX *= -1;

            float x = ((upperLeft.X) / (canvas.Width - size));
            float Y = ((upperLeft.Y) / (canvas.Height - size));

            int R = (int)((c1.R * (x)) + (c2.R * (1 - x)));
            int G = (int)((c1.G * (x)) + (c2.G * (1 - x)));
            int B = (int)((c1.B * (x)) + (c2.B * (1 - x)));

            R = Math.Abs(R);
            G = Math.Abs(G);
            B = Math.Abs(B);

            
            if (R > 255) { R = 255; }
            if (G > 255) { G = 255; }
            if (B > 255) { B = 255; }

            Color color = Color.FromArgb(R, G, B);

            brush = new SolidBrush(color);

            canvas.Invalidate();
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            /*switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        if (e.X > upperLeft.X && e.X <= upperLeft.X+size &&
                            e.Y > upperLeft.X && e.Y <= upperLeft.Y + size)
                        {
                            size = (int)(size*0.7);
                            level++;  
                        }
                    }
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }*/
        }
    }
}
