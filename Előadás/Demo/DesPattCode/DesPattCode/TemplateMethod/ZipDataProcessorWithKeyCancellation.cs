using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.TemplateMethod
{
    class ZipDataProcessorWithKeyCancellation : DataProcessorBase
    {
        protected override void InitCompression()
        {
            Console.WriteLine("Initializing for Zip...");
        }
        protected override void CloseCompression()
        {
            Console.WriteLine("Closing/cleanup for Zip...");
        }
        protected override byte[] CompressData(byte[] data)
        {
            Console.WriteLine("Compressing data using zip ...");
            // Zippelni kellene, itt most csak visszaadjuk az eredeti adatot
            return data;
        }
        protected override bool IsCancelled()
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
