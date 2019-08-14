using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Adapter
{
    // Téglalap alakzat
    class RectShape: Shape
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public RectShape(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        protected override Rect GetBoundingBox()
        {
            return new Rect(X, Y, Width, Height);
        }
    }
}
