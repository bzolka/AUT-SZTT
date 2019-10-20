using System;

namespace DesPattCode.ObserverDocView
{
    class Program
    {

        static void Main(string[] args)
        {
            // Létrehozzuk a dokumentumot
            ExcelDocument doc = new ExcelDocument();

            // Létrehozzuk a két nézetet, konstruktorban átadva a dokumentumot
            // A nézetek az ősosztályuk (ViewBase) konstruktorában be is regisztrálnak a 
            // a dokumentumukhoz (Attach hívás). 
            var tableView = new TableView(doc);
            var columnChartView = new ColumnChartView(doc);

            // Jelenítsük meg a nézeteket
            tableView.Draw();
            columnChartView.Draw();

            Console.WriteLine("Inicializálás kész.");

            Console.WriteLine("Nyomj meg egy billentyűt (111 -> 0,0) cella megváltoztatásához.");
            Console.ReadKey();
            // Megváltoztatjuk a dokumentum/subject állapotát.
            // Azt várjuk, hogy minden beregisztált nézet újra kirajzolja magát, a már friss
            // adatokkal.
            doc.SetCellData(0, 0, 111);
            Console.WriteLine("Cella adat megváltoztatva. Minden nézet a friss adatokat mutatja!");

            Console.WriteLine("Nyomj meg egy billentyűt (222 -> 0,2) cella megváltoztatásához.");
            Console.ReadKey();
            // Megváltoztatjuk a dokumentum/subject állapotát.
            // Azt várjuk, hogy minden beregisztált nézet újra kirajzolja magát, a már friss
            // adatokkal.
            doc.SetCellData(0, 1, 222);
            Console.WriteLine("Cella adat megváltoztatva. Minden nézet a friss adatokat mutatja!");

            Console.WriteLine("Nyomj meg egy billentyűt a TableView-n keresztüli változtatáshoz.");
            // Megváltoztatjuk a dokumentum/subject állapotát.
            // Azt várjuk, hogy minden beregisztált nézet újra kirajzolja magát, a már friss
            // adatokkal.
            tableView.SimulateUserChange();
            Console.WriteLine("Cella adat megváltoztatva. Minden nézet a friss adatokat mutatja!");
            Console.ReadKey();

            // Kilépés előtt
            Console.WriteLine("Nyomj meg egy billentyűt a kilépéshez.");
            Console.ReadKey();
        }
    }
}
