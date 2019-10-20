using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Strategy
{
    public class KeyboardCancellationStrategy : ICancellationStrategy
    {
        ConsoleKey cancelKey;

        public KeyboardCancellationStrategy(ConsoleKey cancelKey)
        {
            this.cancelKey = cancelKey;
        }

        public bool IsCancelled()
        {
            if (!Console.KeyAvailable)
                return false;
            if (Console.ReadKey(true).Key == cancelKey)
            {
                Console.WriteLine("Cancelled.");
                return true;
            }
            return false;
        }
    }
}
