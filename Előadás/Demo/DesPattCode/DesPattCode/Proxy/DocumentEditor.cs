using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Proxy
{
    // A dokumentumszerkesztő osztálya, tárolja a dokumentum
    // objektumait, gondoskodik kirajzolásukról, betöltésükről, stb.
    // A graphics listájában nem Image, hanem ImageProxy objektumok
    // vannak, melyek az Image objektumokat igény szerint töltik be.
    class DocumentEditor
    {
        // A tartalmazott grafikus objektumok (a gyakorlatban
        // ImageProxy objektumok vannak benne).
        List<IGraphic> graphics = new List<IGraphic>();
        const int PegeHeight = 900; // Egy lap magassága pixelben.
        const int SpaceBetweenImages = 30;

        public void Load()
        {
            // Fájlból betöltés helyett fixen létrehozzuk
            // a grafikus alakzatokat.

            // Az Image helyett egy ImageProxy-t veszünk
            // a listába!
            ImageProxy imageProxy;
            imageProxy = new ImageProxy();
            imageProxy.Load();
            graphics.Add(imageProxy);

            // Vegyünk fel még hármat, hogy összesen négy legyen.
            imageProxy = new ImageProxy();
            imageProxy.Load();
            graphics.Add(imageProxy);
            imageProxy = new ImageProxy();
            imageProxy.Load();
            graphics.Add(imageProxy);
            graphics.Add(imageProxy);
            imageProxy = new ImageProxy();
            imageProxy.Load();
            graphics.Add(imageProxy);
        }

        public int GetPageCount()
        {
            // Össz magasság.
            int heightSum = 0;

            // T.f.h a képek egymás alatt vannak, köztük
            // SpaceBetweenImages méretű üres hellyel.
            bool isFirst = true;
            foreach (var g in graphics)
            {
                heightSum += g.GetSize().Height;

                // A képek között hagyjunk ki néhány pixel
                // szabad helyet
                if (isFirst) isFirst = false;
                else heightSum += SpaceBetweenImages;
            }
            // A valóság ennél jelentősen bonyolultabb,
            // de a demónkban egyszerűen osszuk el az össz magasságot
            // a lapmérettel.
            return heightSum / PegeHeight + 1;
        }

        public void DrawFirstPage()
        {
            // Csak azokat rajzoljuk ki, melyek legalább részben kiférnek
            // egymás alá
            int height = 0;
            foreach (var g in graphics)
            {
                if (height > PegeHeight)
                    break;
                g.Draw();
                height += g.GetSize().Height;
            }
        }

    }
}
