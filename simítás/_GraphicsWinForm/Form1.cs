using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _GraphicsDLL;

namespace _GraphicsWinForm
{
    public partial class Form1 : Form
    {
        Graphics g;

        List<Vector2> list = new List<Vector2>();


        public Form1()
        {
            InitializeComponent();

            list.Add(new Vector2(100, 250));
            list.Add(new Vector2(240, 100));
            list.Add(new Vector2(320, 370));
            list.Add(new Vector2(450, 290));
            list.Add(new Vector2(550, 110));
            list.Add(new Vector2(750, 250));
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            for (int i = 0; i < list.Count-1; i++)
            {
                g.DrawLine(Pens.Red,list[i], list[i+1]);
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            Calculate((int)numericUpDown1.Value);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }


        public void Calculate(int round)
        {
            List<Vector2> list1 = new List<Vector2>();

            list1.Add(list[0]);

            list1.Add(new Vector2(list[0].x + ((list[1].x - list[0].x) * ((float)round - 1f) / (float)round),
                                  list[0].y + ((list[1].y - list[0].y) * (((float)round - 1f) / (float)round))));

            for (int i = 0; i < list.Count-2; i++)
            {
                list1.Add(new Vector2(list[i].x + ((list[i + 1].x - list[i].x) * (1f / (float)round)),
                                  list[i].y + ((list[i + 1].y - list[i].y) * (1f / (float)round))));

                list1.Add(new Vector2(list[i].x + ((list[i + 1].x - list[i].x) * ((float)round - 1f) / (float)round),
                                  list[i].y + ((list[i + 1].y - list[i].y) * (((float)round - 1f) / (float)round))));
            }

            list1.Add(new Vector2(list[list.Count - 2].x + ((list[list.Count - 1].x - list[list.Count - 2].x) * (1f / (float)round)),
                                  list[list.Count - 2].y + ((list[list.Count - 1].y - list[list.Count - 2].y) * (1f / (float)round))));

            list1.Add(list[list.Count-1]);

            list = list1;
            canvas.Invalidate();
        }
    }
}
