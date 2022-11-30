using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _GraphicsDLL;

namespace _GraphicsWinForm
{
    public partial class Form1 : Form
    {
        Graphics g;

        int r = 200;

        PointF click = new PointF(0,0);

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawCircle(Pens.Black, new PointF(canvas.Width/2,canvas.Height/2), r);

            if (click != new PointF(0,0))
            {
                
                g.DrawCircle(Color.Red, Color.Blue, new PointF(canvas.Width / 2, canvas.Height / 2), click, r);
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (Math.Abs(canvas.Width / 2 - e.X) < r && Math.Abs(canvas.Height / 2 - e.Y) < r)
            {
                click = new PointF(e.X, e.Y);
                canvas.Invalidate();
            }
            else { MessageBox.Show("Körön kívül kattintottál!", "Hiba"); }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
