using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.TemplateMethod
{
    class ZipDataProcessorWithKeyCancellation : ZipDataProcessor
    {
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
