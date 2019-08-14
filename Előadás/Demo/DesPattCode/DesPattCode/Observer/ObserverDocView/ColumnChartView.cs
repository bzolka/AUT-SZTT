using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.ObserverDocView
{
    // ColumnChartView, a logika egy része a ViewBase ősben van.
    class ColumnChartView : ViewBase
    {
        public ColumnChartView(ExcelDocument doc): base(doc)
        {
        }

        public override void Draw()
        {
            var data = document.GetData();
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ColumnChartView:");

                for (int col = 0; col < ExcelDocument.ColCount; col++)
                {
                    double sum = 0;
                    for (int row = 0; row < ExcelDocument.RowCount; row++)
                    {
                        sum += data[col, row];
                    }
                    Console.Write(sum);
                    Console.Write("\t");
                }
                Console.WriteLine();

            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}
