using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Proxy
{
    // Egyszerű segédosztály méret reprezentálására.
    class Size
    {
        public readonly int Width;
        public readonly int Height;

        public Size(int w, int h)
        {
            if (w < 0)
                throw new ArgumentException("The width can't be negative.");
            if (h < 0)
                throw new ArgumentException("The height can't be negative.");

            Width = w;
            Height = h;
        }
    }
}
