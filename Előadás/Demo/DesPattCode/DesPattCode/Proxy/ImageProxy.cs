using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Proxy
{
    // Tartalmaz egy hivatkozást(image néven) az eredeti
    // kép objektumra. Kezdetben, a dokumentum megnyitásakor
    // ez null, nem lassítjuk a nagyméretű képek betöltésével
    // a folyamatot.
    // A dokumentum megnyitásakor már szükség van
    // a kép méretére (oldalszám meghatározásakor). Az
    // ImageProxy.GetSize() hívódik, mely maga szolgálja ki a
    // kérést a kép cache-elt mérete alapján (ehhez még nem
    // példányosítja és tölti be a képet).
    // Amikor a felhasználó egy képhez görget, akkor a képet ki
    // kell rajzolni: meghívódik az ImageProxy.Draw() művelet.
    // Ehhez már szükség van a kép objektumra is. Az ImageProxy
    // példányosítja a képet és ráállítja az „image” hivatkozását
    // (első kirajzoláskor), majd továbbítja a Draw kérést a kép
    // objektumnak, mely gondoskodik a kirajzolásról.

    class ImageProxy : IGraphic
    {
        // Az "eredeti" objektum, melyet az ImageProxy objektum
        // helyettesít.
        Image image;
        // A kép proxy által cache-elt mérete.
        // Valahol perzisztálni kellene, ezzel az egyszerű
        // demóalkalmazásunkban nem foglalkozunk.
        Size cachedImageSize;

        // Ha ki kell rajzolni a képet, akkor hívódik a Draw.
        // Ezt a proxy magában nem tudja kiszolgálni, be
        // kell töltenie a képet, és a proxy ezt követően
        // továbbhív a képbe, a kirajzolás logikáját a kép
        // tartalmazza (bonyolultabb kód).
        public void Draw()
        {
            Console.WriteLine();

            if (image == null)
            {
                Console.WriteLine("Proxy.Draw, image not yet loaded, loading now");
                image = new Image();
                image.Load();
                Console.WriteLine("Image loaded");
            }


            Console.WriteLine("Proxy.Draw: proxy forwards Draw request to wrapped image object");
            image.Draw();
        }

        public Size GetSize()
        {
            Console.WriteLine("Image size is returned by proxy (no need to load image)");
            // Kép méretének visszaadása
            return cachedImageSize;
        }

        // A dokumentum megnyitásakor hívódik
        // Nem töltjük be a képet, mert a nagyméretű képek
        // betöltése lassítaná a dokumentum megnyitását.
        // Ehelyett csak a kép méretét töltjük be, mert
        // erre szükség van már a dokumentum megnyitásakor is az
        // oldalak betördeléséhez (e nélkül nem tudnánk oldalszámot
        // mondani.
        public void Load()
        {
            // Ebben az egyszerű Proxy demóban betöltés helyett egy
            // beégetett értéket adunk vissza.
            cachedImageSize = new Size(1000, 600);
        }

        public void Save()
        {
            image.Save();
        }

    }
}
