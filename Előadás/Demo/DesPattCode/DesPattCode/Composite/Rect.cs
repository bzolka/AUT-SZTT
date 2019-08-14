using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Composite
{
    // Téglalap alakzat.
    class Rect : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Rect");
        }
    }
}
