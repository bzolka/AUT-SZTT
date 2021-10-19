using System;

namespace DesPattCode.Delegate
{
    class Program
    {

        // A futtatáshoz nevezzük át a függvényt Main-re
        static void Main2(string[] args)
        {
            // Alternatív lehetőségek C#-ban arra, hogyan adjunk át "kódot" egy függvénynek paraméterként
            // Ezek nem tartoznak a tárgyhoz, az "Eseményvezérelt és vizuális programozás" tárgyból
            // kerül részletesebben terítékre.

            // A => operátor után {} között megadjuk a futtatandó kódot (lambda függvény megadása)
            var processor1 = new DataProcessor(() => { return isCancelled(); });

            // Mivel csak egyetlek kifejezés szerepel a {} között, egyszerűsíthetünk,
            // elhagyhatjuk a {}-t és a return-t is (lambda expression megadása)
            var processor2 = new DataProcessor(() => isCancelled());

            // Tulajdonképpen elég a függvény nevét megadni (mivel nincs paramétere a lambdának):
            var processor3 = new DataProcessor(isCancelled);

            // Ha nem írunk külön függvényt az ellenőrzésre, beönthetjük ide az egész lambda
            // fv kódot (vagyis az isCancelled törzsét):
            var processor4 = new DataProcessor(() =>
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
            );


            processor1.Run();
        }

        static bool isCancelled()
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
