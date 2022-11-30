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
        Graphics g;

        PointF upperLeft = new PointF(100, 100);
        float size = 250;
        //Brush brush = Brushes.Salmon;

        Color c1 = Color.Red;
        Color c2 = Color.Blue;

        Brush brush = new SolidBrush(Color.FromArgb(254, 123, 45));

        bool grabbed = false;
        float dx, dy = 0;

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
                g.DrawLine(new Pen(c), upperLeft.X+i, upperLeft.Y, upperLeft.X+i, upperLeft.Y + size);
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (upperLeft.X <= e.X && e.X <= upperLeft.X + size &&
                        upperLeft.Y <= e.Y && e.Y <= upperLeft.Y + size)
                    {
                        grabbed = true;
                        dx = e.X - upperLeft.X;
                        dy = e.Y - upperLeft.Y;
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
            if (grabbed)
            {
                upperLeft = new PointF(e.X - dx, e.Y - dy);

                if (upperLeft.X < 0)
                    upperLeft.X = 0;

                if (upperLeft.X > canvas.Width-size)
                    upperLeft.X = canvas.Width - size;

                if (upperLeft.Y < 0)
                    upperLeft.Y = 0;

                if (upperLeft.Y > canvas.Height - size)
                    upperLeft.Y = canvas.Height - size;

                float x = ((upperLeft.X) / (canvas.Width - size));
                float Y = ((upperLeft.Y) / (canvas.Height - size));

                int R = (int)((c1.R * (x)) + (c2.R * (1 - x)));
                int G = (int)((c1.G * (x)) + (c2.G * (1 - x)));
                int B = (int)((c1.B * (x)) + (c2.B * (1 - x)));

                Color color = Color.FromArgb(R,G,B);

                brush = new SolidBrush(color);

                canvas.Invalidate();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    grabbed = false;
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
        }
    }
}
