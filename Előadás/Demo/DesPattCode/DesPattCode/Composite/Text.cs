using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Composite
{
    // Szöveg alakzat.
    class Text : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Text");
        }
    }
}
