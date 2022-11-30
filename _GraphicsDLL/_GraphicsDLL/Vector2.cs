using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GraphicsDLL
{
    public struct Vector2
    {
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 vector2)
        {
            this.x = vector2.x;
            this.y = vector2.y;
        }

        public float x, y;

        //Átnézni:
        //Operator overloading
        //public static Vector2 operator +(egyik, másik) {return vector;}

        //Átnézni:
        //implicit és explicit típuskonverzió

        public bool IsGrabbedby(Vector2 mouse)
        {
            return Math.Sqrt((this.x - mouse.x) * (this.x - mouse.x) +
                             (this.y - mouse.y) * (this.y - mouse.y)) < ExtensionPointF.GRAB_DISTANCE;
        }
    }
}
