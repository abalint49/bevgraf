using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GraphicsDLL
{
    public class HermiteArc
    {
        public Vector2 p0, p1, t0, t1;
        public float weight;

        //majd kiegészíteni a házi alapján
        public HermiteArc()
        {
            this.p0 = new Vector2(0f, 0f);
            this.p1 = new Vector2(0f, 0f);
            this.t0 = new Vector2(0f, 0f);
            this.t1 = new Vector2(0f, 0f);
        }

        //majd kiegészíteni a házi alapján
        public HermiteArc(Vector2 p0, Vector2 p1, Vector2 t0, Vector2 t1)
        {
            //Mivel struct ezért elhagyhatom, de ha class lenne akkor így lenne érdemesebb, classnál még érdemes írni egy Copy() metódust
            //this.p0 = new Vector2(p0.x, p0.y);
            //this.p1 = new Vector2(p1.x, p1.y);
            //this.t0 = new Vector2(t0.x, t0.y);
            //this.t1 = new Vector2(t1.x, t1.y);

            this.p0 = p0;
            this.p1 = p1;
            this.t0 = t0;
            this.t1 = t1;
        }

        //Megcsinálni a házi alapján
        public HermiteArc(Vector2 p0, Vector2 p1, Vector2 t0, Vector2 t1, float weight)
        {

        }
    }
}
