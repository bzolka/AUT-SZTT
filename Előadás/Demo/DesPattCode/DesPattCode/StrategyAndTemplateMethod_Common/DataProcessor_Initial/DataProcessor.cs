using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Initial
{
    // Kiinduló megoldás, mely közös a Template Method és Strategy tervesési 
    // mintákra.
    // Csak zip algoritmust támogat, és csak billentyűmegnyomással lehet megszakítani 
    // a folyamatot. 
    // Alapelve (a Run függvény az érdekes):
    // * A Run műveletben egy ciklusban olvassa az adatokat, és a beolvasott adatokat
    //   a compressData műveletel zip algoritmussal tömöríti, majd a processCompressedData
    //   hívással folytatódik a feldolgozás.
    // * T.f.h. a tömörítés legelején szükség van egy kezdeti inicializáló a végén pedig 
    //   egy lezáró/takarító lépésre (a gyakorlatban ez szinte mindig így van). Ezeket az 
    //   initZip és closeZip függvények valósítják meg.
    // * Minden feldolgozási iterációban megnézzük, hogy a felhasználó megszakította-e a 
    //   folyamatot (isCancelled művelet), és ha igen, kilépünk a ciklusból.

    class DataProcessor
    {
        // ...

        // Ciklusban beolvassa, tömöríti, majd feldolgozza a tömörített adatokat
        public void Run()
        {
            // Ebben tároljuk a beolvasott, tömörítendő adatokat
            byte[] inputData;
            // T.f.h szükség van zip inicializálásra
            initZip(); 
            try
            {
                while ((inputData = readData()) != null)
                {
                    // Tömöríti az adatokat
                    byte[] compressedData = compressData(inputData);
                    // Feldolgozzuk a tömörített adatot
                    processCompressedData(compressedData);
                    // Ha megszakítás kérés érkezett, kilépünk a ciklusból
                    if (isCancelled())
                        return;
                }
            }
            finally
            {
                // T.f.h szükség van zip lezárására (pl. zip fájl lezárása)
                closeZip();
            }
       
        }

        // Beolvassa az adatok következő halmazát egy byte[]-be
        // Lényegtelen az implementáció
        byte[] readData()
        {
            Console.WriteLine("Reading data from net ...");
            Random random = new Random();
            // Véletlenszerűen detektáljuk az adatok vége állapotot
            if (random.Next(3000) == 1)
                return null;
            // Szimulációként véletelen adatot generálunk
            byte[] data = new byte[100];
            new Random().NextBytes(data);
            return data;
        }
        
        byte[] compressData(byte[] data)
        {
            Console.WriteLine("Compressing data via Zip ...");
            // Zippelni kellene, itt most csak visszaadjuk az eredeti adatot
            return data;
        }

        void  processCompressedData(byte[] data)
        {
            // Feladatfüggő, mit jelent a további feldolgozás (pl. 
            // írhatnánk netre, fájlba, stb.,), itt nem valósítjuk meg.
            Console.WriteLine("Processing compressed data...");
        }

        // Inicializál egy zip adatfolyamot/állományt, nem foglalkozunk az implementációval
        void initZip() { throw new NotImplementedException();  }
        // Lezár egy zip adatfolyamot/állományt, nem foglalkozunk az implementációval
        void closeZip() { throw new NotImplementedException(); }

        // Az X billentyű megnyomása megszakítja a folyamatot
        bool isCancelled()
        {
            if (!Console.KeyAvailable)
                return false;
            if (Console.ReadKey(true).Key == ConsoleKey.X)
            {
                Console.WriteLine("Cancelled.");
                return true;
            }
            return false;
        }

    }
}
