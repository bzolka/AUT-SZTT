using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Strategy
{
    class ZipCompressionStrategy: ICompressionStrategy
    {
        public void InitCompression()
        {
            Console.WriteLine("Initializing for Zip...");
        }

        public byte[] CompressData(byte[] data)
        {
            Console.WriteLine("Compressing data using Zip ...");
            // Zippelni kellene, itt most csak visszaadjuk az eredeti adatot
            return data;
        }

        public void CloseCompression()
        {
            Console.WriteLine("Closing/cleanup for Zip...");
        }
    }
}
