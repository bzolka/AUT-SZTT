namespace _01_NoSeparation_ConsoleUI
{
    internal class Program
    {
        static double minAmountForBatchDiscount = 10;

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

                // Ez itt a logika
                double price = basePrice * amount;
                if (useVat)
                    price = price * 1.27;

                if (amount >= minAmountForBatchDiscount)
                    price = 0.9 * price;

                Console.WriteLine($"Az ár: {price}");
            }
        }
    }
}
