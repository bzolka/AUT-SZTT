using System;

namespace DesPattCode.Strategy
{
    class Program
    {
        // A futtatáshoz nevezzük át a függvényt Main-re
        static void Main2(string[] args)
        {
            // A stratégiák bármilyen kombinációban egyszerűen használhatók. Nézzünk párat!

            // Jelen esetben a Zip algoritmust válaszjuk, és billentyű alapú Cancel lehetőséget
            var processor = new DataProcessor(
                new ZipCompressionStrategy(),
                new KeyboardCancellationStrategy(ConsoleKey.X)
                );
            processor.Run();

            // Második esetben a Rar algoritmust válaszjuk, és nem akarunk Cancel lehetőséget biztosítani
            var processor2 = new DataProcessor(
                new RarCompressionStrategy(),
                new NonCancellableCancellationStrategy()
                );
            processor2.Run();

        }
    }
}
