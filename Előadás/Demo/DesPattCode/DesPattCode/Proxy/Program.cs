using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Proxy
{
    class Program
    {
        // Demonstrálja a proxy működését.
        static void Main2()
        {
            DocumentEditor doc = new DocumentEditor();

            // Betöltés és oldalszám meghatározása. Itt a képek nem fognak 
            // létrejönni és betöltődni, mert az oldalszám meghatázozásához
            // nem kellenek a pixelek, elég a képek mérete, és ezt az 
            // információt a proxy (ImageProxy) objektumok is vissza 
            // tudják adni.
            doc.Load();
            Console.WriteLine("Page count: " + doc.GetPageCount());

            // Rajzoljuk ki az első oldalt. Amíg a felhasználó nem görget
            // tovább, csak ezt kell megjeleníteni. Bár három kép is van a
            // dokumentumban, a példánkban csak kettő fog ekkor betöltődni, 
            // mert a harmadikból nem látszik semmi az első oldalon.
            doc.DrawFirstPage();

            // ..
        }
    }
}
