using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Delegate
{
    // Csak zip algoritmust támogat.
    // A megszakítás (cancel) kódja egy metódusrefencia/lambda formájában adható át, 
    // konstruktor paraméterként.
    // A tömörítő algoritmus tekintetében való kiterjeszhtetőség bármelyik technikával megoldható
    // (template method v. strategy v. metódusreferencia/lambda használata). Haladóknak
    // gyakorlásképpen javasolt a metódusreferencia/lambda alapú megoldás megvalósítása.
    class DataProcessor
    {
        // ...

        Func<bool> isCancelled;  // Metódusreferencia, konstruktorban kapja meg, Run-ban hívjuk

        public DataProcessor(Func<bool> isCancelled)
        {
            this.isCancelled = isCancelled;
        }

        // Ciklusban beolvassa, tömöríti, majd feldolgozza a tömörített adatokat
        public void Run()
        {
            byte[] inputData; // Ebben tároljuk a beolvasott, tömörítendő adatokat
            initZip(); // T.f.h szükség van zip inicializálásra
            try
            {
                while ((inputData = readData()) != null)
                {
                    byte[] compressedData = compressData(inputData);
                    processCompressedData(compressedData);
                    if (isCancelled != null && isCancelled())
                        return;
                }
            }
            finally
            {
                closeZip(); // T.f.h szükség van zip lezárására (pl. zip fájl lezárása)
            }
       
        }

        // Beolvassa az adatok következő halmazát egy byte[]-be
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

        void  processCompressedData(byte[] data) { Console.WriteLine("Processing compressed data..."); }

        // Inicializál egy zip adatfolyamot/állományt, nem foglalkozunk az implementációval
        void initZip() { Console.WriteLine("Initializing for Zip..."); }
        // Lezár egy zip adatfolyamot/állományt, nem foglalkozunk az implementációval
        void closeZip() { Console.WriteLine("Closing/cleanup for Zip..."); }

        // Az X billentyű megnyomása megszakítja a folyamatot


    }
}
