using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GraphicsDLL
{
    public class Bezier3Curve
    {
        public Vector2 p0, p1, p2, p3;

        public Bezier3Curve(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }
    }
}
