using System;

namespace DesPattCode.TemplateMethod
{
    class Program
    {
        static void Main2(string[] args)
        {
            var processor = new ZipDataProcessorWithKeyCancellation();
            processor.Run();
        }
    }
}
