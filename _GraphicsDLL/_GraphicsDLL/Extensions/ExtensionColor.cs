using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GraphicsDLL
{
    public static class ExtensionColor
    {
        public static bool IsTheSameAs(this Color c1, Color c2)
        {
            return c1.R == c2.R &&
                   c1.G == c2.G &&
                   c1.B == c2.B;
        }
    }
}
