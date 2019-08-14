using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Adapter
{
    // Vonal alakzat
    class LineShape : Shape
    {
        public int StartX;
        public int StartY;
        public int EndX;
        public int EndY;

        public LineShape(int startX, int startY, int endX, int endY)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }

        protected override Rect GetBoundingBox()
        {
            return new Rect(StartX, StartY, EndX - StartX, EndY - StartY);
        }
    }
}
