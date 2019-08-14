using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Adapter
{
    // Egyszerű segédosztály, egy téglalapot reprezentál
    class Rect
    {
        public int X;
        public int Y;
        public int W;
        public int H;

        public Rect(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }
    }
}
