using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Strategy
{
    public class RarCompressionStrategy: ICompressionStrategy
    {
        public void InitCompression()
        {
            Console.WriteLine("Initializing for Rar ...");
        }

        public byte[] CompressData(byte[] data)
        {
            Console.WriteLine("Compressing data using Rar ...");
            // Zippelni kellene, itt most csak visszaadjuk az eredeti adatot
            return data;
        }

        public void CloseCompression()
        {
            Console.WriteLine("Closing/cleanup for Rar ...");
        }
    }
}
