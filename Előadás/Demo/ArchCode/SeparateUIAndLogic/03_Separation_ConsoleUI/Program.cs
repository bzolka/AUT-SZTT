using Initial;

namespace _01_NoSeparation_ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // UI rész
                Console.WriteLine("Add meg az alapárat:");
                var basePrice = double.Parse(Console.ReadLine());

                Console.WriteLine("Add meg a mennyiséget:");
                var amount = double.Parse(Console.ReadLine());

                Console.WriteLine("Számítsuk bele az ÁFÁ-t? (i/n):");
                var useVat = Console.ReadLine().ToLower() == "i";

                // Itt csak használjuk a logikát
                var productLine = new ProductLine(basePrice, amount,useVat);

                Console.WriteLine($"Az ár: {productLine.GetPrice()}");
            }
        }
    }
}
