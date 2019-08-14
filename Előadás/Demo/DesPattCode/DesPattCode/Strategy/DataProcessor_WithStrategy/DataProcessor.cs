using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesPattCode.Strategy
{
    class DataProcessor
    {
        ICompressionStrategy compressionStrategy; // Aktuális tömörítési stratégia/viselkedés
        ICancellationStrategy cancellationStrategy; // Aktuális cancel stratégia/viselkedés

        public DataProcessor(ICompressionStrategy compressionStrategy, ICancellationStrategy cancellationStrategy)
        {
            // Ügyelünk arra, hogy null-t nem fogadunk el, az osztály függőségeit kötelező megadni
            if (compressionStrategy == null) throw new ArgumentNullException(nameof(compressionStrategy));
            if (cancellationStrategy == null) throw new ArgumentNullException(nameof(cancellationStrategy));

            // Eltároljuk a paraméterként kapott stratégiákat
            this.compressionStrategy = compressionStrategy;
            this.cancellationStrategy = cancellationStrategy;
        }

        // Ciklusban beolvassa, tömöríti, majd feldolgozza a tömörített adatokat
        public void Run()
        {
            byte[] inputData;
            compressionStrategy.InitCompression(); // Tömörítés inicializás, impl. függő
            try
            {
                while ((inputData = readData()) != null)
                {
                    // Tömörítés, impl. függő
                    byte[] compressedData = compressionStrategy.CompressData(inputData);
                    processCompressedData(compressedData);
                    if (cancellationStrategy.IsCancelled())  // Cancel vizsgálat, impl. függő
                        return;
                }
            }
            finally
            {
                compressionStrategy.CloseCompression(); // Tömörítés lezárás, impl. függő
            }
        }

        byte[] readData()
        {
            Console.WriteLine("Reading data from net ...");
            // Szimulációként véletelen adatot generálunk
            Random random = new Random();
            // Véletlenszerűen detektáljuk az adatok vége állapotot
            if (random.Next(3000) == 1)
                return null;
            byte[] data = new byte[100];
            new Random().NextBytes(data);
            Thread.Sleep(100);
            return data;
        }

        void processCompressedData(byte[] data)
        {
            Console.WriteLine("Processing compressed data...");
        }

    }
}
