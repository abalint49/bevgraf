using _GraphicsDLL.Curves;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _GraphicsDLL
{
    public static class ExtensionGraphics
    {
        //Házi!
        #region DrawPixel
        public static void DrawPixel(this Graphics g,
            Pen pen, float x, float y)
        {
            g.DrawRectangle(pen, x, y, 0.5f, 0.5f);
        }

        //Házi:
        //(color, x, y)
        //(color, pointf)
        //(color, point)
        //(pen, pointf)

        #endregion

        #region DrawLine

        public static void DrawLine(this Graphics g,
            Pen pen, Vector2 p0, Vector2 p1)
        {
            g.DrawLine(pen, p0.x, p0.y, p1.x, p1.y);
        }

        public static void DrawLine(this Graphics g,
            Pen pen, Vector4 p0, Vector4 p1)
        {
            g.DrawLine(pen, (float)p0.x, (float)p0.y, (float)p1.x, (float)p1.y);
        }

        #endregion

        //Házi!
        #region DrawLineDDA

        public static void DrawLineDDA(this Graphics g,
            Pen pen, float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            float length = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            float incX = dx / length;
            float incY = dy / length;

            float x = x1;
            float y = y1;

            g.DrawPixel(pen, x, y);
            for (int i = 0; i < length; i++)
            {
                //g.DrawPixel(pen, x, y);
                x += incX;
                y += incY;
                g.DrawPixel(pen, x, y);
            }
            //g.DrawPixel(pen, x, y);
        }

        public static void DrawLineDDA(this Graphics g,
            Pen pen, PointF p1, PointF p2)
        {
            g.DrawLineDDA(pen, p1.X, p1.Y, p2.X, p2.Y);
        }

        public static void DrawLineDDA(this Graphics g,
            Pen pen, Point p1, Point p2)
        {
            g.DrawLineDDA(pen, p1.X, p1.Y, p2.X, p2.Y);
        }

        public static void DrawLineDDA(this Graphics g,
            Pen pen, int x1, int y1, int x2, int y2)
        {
            g.DrawLineDDA(pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //----------- Házi feladat! --------------

        public static void DrawLineDDA(this Graphics g,
            Color c1, Color c2, float x1, float y1, float x2, float y2)
        {
            Pen pen = new Pen(Color.FromArgb(255,c1),2f);

            float dx = x2 - x1;
            float dy = y2 - y1;

            float length = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            float incX = dx / length;
            float incY = dy / length;

            float x = x1;
            float y = y1;

            float stepR = (c2.R - c1.R) / length;
            float stepG = (c2.G - c1.G) / length;
            float stepB = (c2.B - c1.B) / length;

            float R = c1.R ;
            float G = c1.G ;
            float B = c1.B ;

            g.DrawPixel(pen, (float)x, (float)y);
            for (int i = 0; i < length; i++)
            {
                R = R + stepR;
                G = G + stepG;
                B = B + stepB;
                pen = new Pen(Color.FromArgb(255,(int)R, (int)G, (int)B),2f);
                x += incX;
                y += incY;
                g.DrawPixel(pen, (float)x, (float)y);
            }
        }

        public static void DrawLineDDA(this Graphics g,
            Color c1, Color c2, PointF p1, PointF p2)
        {
            DrawLineDDA(g,c1, c2, p1.X, p1.Y, p2.X, p2.Y);
        }

        //-----------------------------------------

        #endregion

        //Házi! 10.19 - Vector2-t használó metódus
        #region DrawPoint

        public static void DrawPoint(this Graphics g,
            Pen pen, Brush brush,
            PointF p, float r)
        {
            g.FillEllipse(brush, p.X - r, p.Y - r, 2 * r, 2 * r);
            g.DrawEllipse(pen, p.X - r, p.Y - r, 2 * r, 2 * r);
        }

        public static void DrawPoint(this Graphics g,
            Pen pen, Brush brush,
            Vector2 v, float r)
        {
            g.FillEllipse(brush, v.x - r, v.y - r, 2 * r, 2 * r);
            g.DrawEllipse(pen, v.x - r, v.y - r, 2 * r, 2 * r);
        }

        #endregion

        //Házi!
        #region DrawPolygon

        public static void DrawPolygonDDA(this Graphics g,
            Pen pen, PointF[] points, bool closed = false)
        {

        }

        public static void DrawPolygon(this Graphics g,
            Color[] colors, PointF[] points, bool closed = false)
        {

        }



        #endregion

        //Házi!
        #region DrawMidPointLine

        //Midpoint egyenes


        #endregion

        #region DrawCircle

        //-------Challenge----------
        //Midpoint kör + színátmenet/színkör

        public static void DrawCircle(this Graphics g,
            Pen pen, PointF center, float r)
        {
            float x = 0;
            float y = r;
            //h a döntési változó
            float h = 1.0f - r;

            g.DrawCirclePixels(pen, center.X, center.Y, x, y);

            while(y > x)
            {
                //matek
                if (h < 0)
                    h += 2 * x + 3;
                else
                {
                    h += 2 * (x - y) + 5;
                    y--;
                }
                x++;
                g.DrawCirclePixels(pen, center.X, center.Y, x, y);
            }
        }

        //Házi
        public static void DrawCircle(this Graphics g,
            Color c1, Color c2, PointF center, float r)
        {

        }

        public static void DrawCirclePixels(this Graphics g,
            Pen pen, float cx, float cy, float x, float y)
        {
            g.DrawPixel(pen, cx + x, cy + y);
            g.DrawPixel(pen, cx + x, cy - y);
            g.DrawPixel(pen, cx - x, cy - y);
            g.DrawPixel(pen, cx - x, cy + y);

            g.DrawPixel(pen, cx + y, cy + x);
            g.DrawPixel(pen, cx + y, cy - x);
            g.DrawPixel(pen, cx - y, cy - x);
            g.DrawPixel(pen, cx - y, cy + x);
        }


        public static void DrawCircle(this Graphics g,
            Color c1, Color c2, PointF center , PointF click, float r)
        {
            float x = 0;
            float y = r;
            //h a döntési változó
            float h = 1.0f - r;


            g.DrawCirclePixels(c1,c2, center.X, center.Y, x, y,click.X,click.Y);

            while (y > x)
            {
                //matek
                if (h < 0)
                    h += 2 * x + 3;
                else
                {
                    h += 2 * (x - y) + 5;
                    y--;
                }
                x++;
                g.DrawCirclePixels(c1, c2, center.X, center.Y, x, y, click.X, click.Y);
            }
        }

        public static void DrawCirclePixels(this Graphics g,
            Color c1, Color c2, float cx, float cy, float x, float y,float px, float py)
        {
            g.DrawLineDDA(c1, c2, px, py, cx + x, cy + y);
            g.DrawLineDDA(c1, c2, px, py, cx + x, cy - y);
            g.DrawLineDDA(c1, c2, px, py, cx - x, cy - y);
            g.DrawLineDDA(c1, c2, px, py, cx - x, cy + y);

            g.DrawLineDDA(c1, c2, px, py, cx + y, cy + x);
            g.DrawLineDDA(c1, c2, px, py, cx + y, cy - x);
            g.DrawLineDDA(c1, c2, px, py, cx - y, cy - x);
            g.DrawLineDDA(c1, c2, px, py, cx - y, cy + x);
        }

        #endregion

        //Házi!
        #region CohenSutherland

        private const byte TOP_CODE = 8;        //1000
        private const byte BOTTOM_CODE = 4;     //0100
        private const byte LEFT_CODE = 2;       //0010
        private const byte RIGHT_CODE = 1;      //0001

        private static byte OuterCode(Rectangle window, PointF p)
        {
            byte code = 0;  //0000

            if (p.X < window.Left)          code |= LEFT_CODE;
            else if (p.X > window.Right)    code |= RIGHT_CODE;

            if (p.Y < window.Top)           code |= TOP_CODE;
            else if (p.Y > window.Bottom)   code |= BOTTOM_CODE;

            return code;
        }

        //Házi!
        public static void Clip(this Graphics g,
            Pen pen, Rectangle window, PointF p0, PointF p1)
        {
            byte code0 = OuterCode(window, p0);
            byte code1 = OuterCode(window, p1);
            bool accept = false;

            while(true)
            {
                //Elfogadom vágás nélkül
                if((code0 | code1) == 0)
                {
                    accept = true;
                    break;
                }

                //Elutasítom, mert kint van az egyik oldalon
                if ((code0 & code1) != 0)
                    break;

                //Vágni kell
                else
                {
                    byte code = code0 != 0 ? code0 : code1;
                    float x = 0, y = 0;

                    if((code & TOP_CODE) != 0)
                    {
                        x = p0.X + (p1.X - p0.X) * (window.Top - p0.Y) / (p1.Y - p0.Y);
                        y = window.Top;
                    }
                    else if ((code & BOTTOM_CODE) != 0)
                    {
                        x = p0.X + (p1.X - p0.X) * (window.Bottom - p0.Y) / (p1.Y - p0.Y);
                        y = window.Bottom;
                    }
                    if((code & LEFT_CODE) != 0)
                    {
                        x = window.Left;
                        y = p0.Y + (p1.Y - p0.Y) * (window.Left - p0.X) / (p1.X - p0.X);
                    }
                    else if ((code & RIGHT_CODE) != 0)
                    {
                        x = window.Right;
                        y = p0.Y + (p1.Y - p0.Y) * (window.Right - p0.X) / (p1.X - p0.X);
                    }

                    if (code == code0)
                    {
                        p0.X = x;
                        p0.Y = y;
                        code0 = OuterCode(window, p0);
                    }
                    else
                    {
                        p1.X = x;
                        p1.Y = y;
                        code1 = OuterCode(window, p1);
                    }
                }
            }

            if (accept)
                g.DrawLine(pen, p0, p1);
        }

        #endregion

        #region ParametricCurve2D

        public static void DrawParametricCurve2D(this Graphics g,
            Pen pen, Func<double, double> X, Func<double, double> Y,
            double a, double b, double scale = 1.0,
            double cX = 0, double cY = 0, double n = 500.0)
        {
            if (a >= b) throw new Exception("Invalid interval!");

            double t = a;
            double h = (b - a) / n;

            PointF p0 = new PointF((float)(scale * X(t) + cX),
                                   (float)(scale * Y(t) + cY));

            while(t < b)
            {
                t += h;
                PointF p1 = new PointF((float)(scale * X(t) + cX),
                                       (float)(scale * Y(t) + cY));
                g.DrawLine(pen, p0, p1);
                p0 = p1;
            }
        }

        #endregion

        #region HermiteArc

        //PointF-fel
        public static void DrawHermiteArc(this Graphics g,
            Pen pen, PointF p0, PointF p1, PointF t0, PointF t1)
        {
            g.DrawParametricCurve2D(pen,
                t => Hermite.H0(t) * p0.X + Hermite.H1(t) * p1.X +
                     Hermite.H2(t) * t0.X + Hermite.H3(t) * t1.X,
                t => Hermite.H0(t) * p0.Y + Hermite.H1(t) * p1.Y +
                     Hermite.H2(t) * t0.Y + Hermite.H3(t) * t1.Y,
                0.0, 1.0);
        }

        //Vector2-vel
        public static void DrawHermiteArc(this Graphics g,
            Pen pen, Vector2 p0, Vector2 p1, Vector2 t0, Vector2 t1)
        {
            g.DrawParametricCurve2D(pen,
                t => Hermite.H0(t) * p0.x + Hermite.H1(t) * p1.x +
                     Hermite.H2(t) * t0.x + Hermite.H3(t) * t1.x,
                t => Hermite.H0(t) * p0.y + Hermite.H1(t) * p1.y +
                     Hermite.H2(t) * t0.y + Hermite.H3(t) * t1.y,
                0.0, 1.0);
        }

        public static void DrawHermiteArc(this Graphics g,
            Pen pen, HermiteArc arc)
        {
            g.DrawHermiteArc(pen, arc.p0, arc.p1, arc.t0, arc.t1);
        }

        public static void DrawHermiteArcM(this Graphics g,
            Pen pen, HermiteArc arc)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region BezierCurve

        public static void DrawBezier3(this Graphics g,
            Pen pen, Bezier3Curve curve)
        {
            g.DrawParametricCurve2D(pen,
                t => Bezier3.B0(t) * curve.p0.x + Bezier3.B1(t) * curve.p1.x +
                     Bezier3.B2(t) * curve.p2.x + Bezier3.B3(t) * curve.p3.x,
                t => Bezier3.B0(t) * curve.p0.y + Bezier3.B1(t) * curve.p1.y +
                     Bezier3.B2(t) * curve.p2.y + Bezier3.B3(t) * curve.p3.y,
                0.0, 1.0);
        }

        public static void DrawBezier3M(this Graphics g,
            Pen pen, HermiteArc arc)
        {
            throw new NotImplementedException();
        }
        public static void DrawBezier3K(this Graphics g, Pen pen, Bezier3KCurve curve)
        {
            throw new NotImplementedException();
        }
        public static void DrawBezierN(this Graphics g, Pen pen, BezierNCurve curve)
        {
            throw new NotImplementedException();
        }
        public static void DrawBezierNdeCasteljouRec(this Graphics g, Pen pen, BezierNCurve curve)
        {
            throw new NotImplementedException();
        }
        public static void DrawBezierNdeCasteljouIter(this Graphics g, Pen pen, BezierNCurve curve)
        {
            throw new NotImplementedException();
        }
        public static void DrawBSpline(this Graphics g, Pen pen, BSplineCurve curve)
        {
            throw new NotImplementedException();
        }
        public static void DrawBSplineM(this Graphics g, Pen pen, BSplineCurve curve)
        {
            throw new NotImplementedException();
        }
        public static void DrawBSpline(this Graphics g, Color c0, Color c1, List<BSplineCurve> curve)
        {
            throw new NotImplementedException();
        }
        public static void DrawBSplineM(this Graphics g, Color c0, Color c1, List<BSplineCurve> curve)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region DrawParametricCurve3D

        //Házi!
        public static void DrawParametricCurve3D(this Graphics g,
            Pen pen,
            Func<double, double> X, Func<double, double> Y, Func<double, double> Z,
            double a, double b,
            /* Matrix4 trasformation, */ Matrix4 projection,
            Vector4 translate2D,
            double n = 500.0)
        {
            double t = a;
            double h = (b - a) / n;

            Vector4 v0 = new Vector4(X(t), Y(t), Z(t));

            while (t < b)
            {
                t += h;
                Vector4 v1 = new Vector4(X(t), Y(t), Z(t));

                Vector4 pv0 = projection * v0 + translate2D;
                Vector4 pv1 = projection * v1 + translate2D;

                g.DrawLine(pen, (float)pv0.x, (float)pv0.y, (float)pv1.x, (float)pv1.y);
                v0 = v1;
            }
        }

        public static void DrawParametricCurve3D(this Graphics g,
            Pen pen,
            Func<double, double> X, Func<double, double> Y, Func<double, double> Z,
            double a, double b,
            Matrix4 trasformation, Matrix4 projection,
            Vector4 translate2D,
            double n = 500.0)
        {
            double t = a;
            double h = (b - a) / n;

            Vector4 v0 = new Vector4(X(t), Y(t), Z(t));

            Matrix4 m = projection * trasformation;

            while (t < b)
            {
                t += h;
                Vector4 v1 = new Vector4(X(t), Y(t), Z(t));

                Vector4 pv0 = m * v0 + translate2D;
                Vector4 pv1 = m * v1 + translate2D;

                g.DrawLine(pen, (float)pv0.x, (float)pv0.y, (float)pv1.x, (float)pv1.y);
                v0 = v1;
            }
        }

        #endregion

        #region ParametricSurface

        public static void DrawParametricSurfaceWithLine(this Graphics g,
            Pen pen,
            Func<double, double, double> X,
            Func<double, double, double> Y,
            Func<double, double, double> Z,
            double a, double b,
            double c, double d,
            Matrix4 transformation, Matrix4 projection,
            Vector4 translate2D,
            double n1 = 100.0, double n2 = 100.0)
        {
            double u = a;
            while(u <= b)
            {
                g.DrawParametricCurve3D(pen,
                    T => X(T, u),
                    T => Y(T, u),
                    T => Z(T, u),
                    c, d,
                    transformation, projection, translate2D);
                u += (b - a) / n2;
            }
            double t = c;
            while (t <= d)
            {
                g.DrawParametricCurve3D(pen,
                    U => X(t, U),
                    U => Y(t, U),
                    U => Z(t, U),
                    a, b,
                    transformation, projection, translate2D);
                t += (d - c) / n1;
            }
        }

        #endregion
    }
}
