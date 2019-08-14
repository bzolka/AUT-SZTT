using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;



namespace DesPattCode.TemplateMethod
{
    // Csak zip algoritmust támogat
    abstract class DataProcessorBase
    {
        // ...

        // Ciklusban beolvassa, tömöríti, majd feldolgozza a tömörített adatokat
        public void Run()
        {
            byte[] inputData;
            InitCompression(); // Tömörítés inicializás, impl. függő
            try
            {
                while ((inputData = readData()) != null)
                {
                    // Tömörítés, impl. függő
                    byte[] compressedData = CompressData(inputData);
                    processCompressedData(compressedData);
                    if (IsCancelled()) // Cancel vizsgálat, impl. függő
                        return;
                }
            }
            finally
            {
                CloseCompression(); // Tömörítés lezárás, impl. függő
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
        
        void  processCompressedData(byte[] data)
        {
            Console.WriteLine("Processing compressed data...");
        }

        // Egyes tömörítő algortimusoknál sükség lehet kezdeti inizializáló lépésre
        protected virtual void InitCompression() { } 
        protected abstract byte[] CompressData(byte[] data);
        protected virtual void CloseCompression() { }

        protected virtual bool IsCancelled() { return false; }
    }
}
