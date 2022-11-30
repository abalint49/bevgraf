using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GraphicsDLL
{
    public static class ExtensionBitmap
    {
        public static void SetLine(this Bitmap bmp,
            Color color, float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            float length = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            float incX = dx / length;
            float incY = dy / length;

            float x = x1;
            float y = y1;

            bmp.SetPixel((int)x, (int)y, color);
            for (int i = 0; i < length; i++)
            {
                x += incX;
                y += incY;
                bmp.SetPixel((int)x, (int)y, color);
            }
        }

        public static void FillRec4(this Bitmap bmp,
            Color backgColor, Color fillColor, int x, int y)
        {
            if(backgColor.IsTheSameAs(bmp.GetPixel(x, y)))
            {
                bmp.SetPixel(x, y, fillColor);
                bmp.FillRec4(backgColor, fillColor, x, y + 1); //lent
                bmp.FillRec4(backgColor, fillColor, x, y - 1); //fent
                bmp.FillRec4(backgColor, fillColor, x + 1, y); //jobbra
                bmp.FillRec4(backgColor, fillColor, x - 1, y); //balra
            }
            //Ha nem lép be az if-be adott rekurzív hívás vége
        }

        // aki nagyon szeretne utánanézhet, hogy ne lépjen ki átlós körvonalnál az alakzatból
        // aki végképp nagyon szeretné implementálhatja is
        public static void FillRec8(this Bitmap bmp,
            Color backgColor, Color fillColor, int x, int y)
        {
            //if (backgColor.R == bmp.GetPixel(x, y).R &&
            //   backgColor.G == bmp.GetPixel(x, y).G &&
            //   backgColor.B == bmp.GetPixel(x, y).B)
            if (backgColor.IsTheSameAs(bmp.GetPixel(x, y)))
            {
                bmp.SetPixel(x, y, fillColor);                     //canvas szerinti koorináták
                bmp.FillRec8(backgColor, fillColor, x, y + 1);     //lent
                bmp.FillRec8(backgColor, fillColor, x, y - 1);     //fent
                bmp.FillRec8(backgColor, fillColor, x + 1, y);     //jobbra
                bmp.FillRec8(backgColor, fillColor, x - 1, y);     //balra
                           
                bmp.FillRec8(backgColor, fillColor, x + 1, y + 1); //jobb-lent
                bmp.FillRec8(backgColor, fillColor, x - 1, y + 1); //bal-lent
                bmp.FillRec8(backgColor, fillColor, x + 1, y - 1); //jobb-fent
                bmp.FillRec8(backgColor, fillColor, x - 1, y - 1); //bal-fent
            }
            //Ha nem lép be az if-be adott rekurzív hívás vége
        }

        public static void FillStack4(this Bitmap bmp,
            Color backgColor, Color fillColor, int x, int y)
        {
            int[] dx = new int[] {1, 0, -1,  0};
            int[] dy = new int[] {0, 1,  0, -1};

            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));

            Point p;
            while(stack.Count > 0)
            {
                p = stack.Pop();
                bmp.SetPixel(p.X, p.Y, fillColor);

                for (int i = 0; i < 4; i++)
                {
                    int x0 = p.X + dx[i];
                    int y0 = p.Y + dy[i];

                    if (x0 > 0 && x0 < bmp.Width && y0 > 0 && y0 < bmp.Height &&
                        backgColor.IsTheSameAs(bmp.GetPixel(x0, y0)))
                        stack.Push(new Point(x0, y0));
                }
            }
        }

        #region SuperSampling

        public static Bitmap Supersampling(this Bitmap bmp)
        {
            Bitmap res = new Bitmap(bmp.Width, bmp.Height);

            Color c0, c1, c2, c3;
            int r, g, b;
            List<Color> colors = new List<Color>();

            for (int y = 0; y < bmp.Height - 1; y++)
            {
                for (int x = 0; x < bmp.Width - 1; x++)
                {
                    c0 = bmp.GetPixel(x, y);
                    c1 = bmp.GetPixel(x + 1, y);
                    c2 = bmp.GetPixel(x, y + 1);
                    c3 = bmp.GetPixel(x + 1, y + 1);

                    r = (c0.R + c1.R + c2.R + c3.R) / 4;
                    g = (c0.G + c1.G + c2.G + c3.G) / 4;
                    b = (c0.B + c1.B + c2.B + c3.B) / 4;

                    res.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            for (int x = 0; x < bmp.Width; x++)
                res.SetPixel(x, bmp.Height - 1, bmp.GetPixel(x, bmp.Height - 1));
            for (int y = 0; y < bmp.Height; y++)
                res.SetPixel(bmp.Width - 1, y, bmp.GetPixel(bmp.Width - 1, y));

            return res;
        }

        #endregion
    }
}
