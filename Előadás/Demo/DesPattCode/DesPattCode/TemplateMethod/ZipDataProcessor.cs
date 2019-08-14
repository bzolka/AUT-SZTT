using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.TemplateMethod
{
    class ZipDataProcessor : DataProcessorBase
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
    }
}
