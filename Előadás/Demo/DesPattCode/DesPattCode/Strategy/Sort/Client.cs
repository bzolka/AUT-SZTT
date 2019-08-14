using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Strategy.Sort
{
    // Strategy interfész
    interface ISortStrategy
    {
        void Sort(string[] items);
    }

    // QuickSort strategy implementáció
    class QuickSort : ISortStrategy
    {
        public void Sort(string[] items)
        {
            Console.WriteLine("Sorting items using quick sort algoritm ...");
        }
    }

    // HeapSort strategy implementáció
    class HeapSort : ISortStrategy
    {
        public void Sort(string[] items)
        {
            Console.WriteLine("Sorting items using heap sort algoritm ...");
        }
    }

    // Kliens, a Sort metódusa az aktuálisan beállított stratégiával rendez
    class Client
    {
        ISortStrategy sort; // Hivatkozás az aktuálisan beaállított stratégia implementációra

        // Lehetőséget biztosít a stratégia beállítására
        public void SetSortStrategy(ISortStrategy sort)
        {
            this.sort = sort;
        }

        public void Sort(string[] items)
        {
            sort.Sort(items); // Sorrendezés az aktuális stratégiával
        }
    }

    

}
