using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.ObserverDocView
{
    // TableView, a logika egy része a ViewBase ősben van.
    class TableView : ViewBase
    {
        public TableView(ExcelDocument doc) : base(doc)
        {
        }


        public override void Draw()
        {
            var data = document.GetData();
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("TableView:");
                for (int row = 0; row < ExcelDocument.RowCount; row++)
                {
                    for (int col = 0; col < ExcelDocument.ColCount; col++)
                    {
                        Console.Write(data[col, row]);
                        Console.Write("\t");
                    }
                    Console.WriteLine();
                }
            }
            finally
            {
                Console.ResetColor();
            }
        }

        // Bekéri a felhasználótól a két koordinátát, majd az új értéket, 
        // és megváltozatatja a dokumentum tartalmát. Azt szimulálja, mintha egy 
        // valódi táblázatkezelőben a cellában átírna a felhasználó egy értéket.
        public void SimulateUserChange()
        {
            Console.WriteLine("TableView, adja meg a koordinátákat és az új cella értéket: ");
            Console.Write("Oszlop: ");
            int col = int.Parse(Console.ReadLine());
            Console.Write("Sor: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Érték: ");
            double data = Double.Parse(Console.ReadLine());
            document.SetCellData(col, row, data);
        }
    }
}
