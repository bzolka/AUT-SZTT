using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Composite
{
    // Vonal alakzat.
    class Line : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Line");
        }
    }
}
