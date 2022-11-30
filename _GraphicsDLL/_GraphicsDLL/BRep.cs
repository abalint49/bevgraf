using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GraphicsDLL
{
    class BRep
    {
        List<Vector4> vertices;
        List<Edge> edges;
        List<Thriangle> thriangles;

        
    }

    public class Thriangle
    {
        public Vector4 v0, v1, v2;

        public Thriangle(Vector4 v0, Vector4 v1, Vector4 v2)
        {
            this.v0 = v0;
            this.v1 = v1;
            this.v2 = v2;
        }

        public static Thriangle operator +(Thriangle t, Vector4 v)
        {
            return new Thriangle(t.v0+v, t.v1+v, t.v2+v);
        }
    }

    public class Edge
    {
        public Vector4 v0, v1;

        public Edge(Vector4 v0,Vector4 v1)
        {
            this.v0 = v0;
            this.v1 = v1;
        }
    }

    public class Cube : CubeBase, BRep
    {
        public Cube()
        {
            LoadCube();
        }
    }
}
