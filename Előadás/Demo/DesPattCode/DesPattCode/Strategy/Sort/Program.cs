using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Strategy.Sort
{
    class Program
    {
        // A futtatáshoz nevezzük át a függvényt Main-re
        static void Main2(string[] args)
        {
            var items = new string[] { "körte", "alma", "szilva" };

            Client client = new Client();

            // Kezdetben használjuk a quick sort algoritmust
            client.SetSortStrategy(new QuickSort());
            client.Sort(items);

            // Mostantól a heap sort algoritmust használjuk
            client.SetSortStrategy(new HeapSort());
            client.Sort(items);
        }
    }
}
