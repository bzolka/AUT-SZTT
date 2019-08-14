using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Proxy
{
    // Egy képet reprezentál, a kapcsolódó műveleteket,
    // mint például kirajzolás, betöltés, mentés fogja össze.
    class Image : IGraphic
    {
        Size size;
        int[,] pixels;

        public Image ()
        {
        }

        public void Draw()
        {
            Console.WriteLine("Image object is drawn" );
        }

        public Size GetSize()
        {
            Console.WriteLine("Image size is returned image");
            return new Size(100, 80);
        }

        public void Load()
        {
            // Itt töltnénk be a pixeleket egy fájlból egy
            // tagváltozóba.  
            // Ezen felül a méretet is inicializáljuk a fájl 
            // alapján (de ennek nincs a minta szempontjábbl
            // semmi jelentősége)
            size = new Size(1000, 800);
            pixels = new int[size.Width, size.Height];
            Console.WriteLine("Image object is loaded.");
        }

        public void Save()
        {
            Console.WriteLine("Image object is saved.");
        }
    }
}
