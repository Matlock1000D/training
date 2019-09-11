using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Pen testikyna = new Pen(Brushes.DeepSkyBlue);
            testikyna.Width = 0.8F;
            testikyna.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            DrawLine(testikyna, 0, 0, 500, 500);
            testikyna.Dispose;

        }
    }
}
