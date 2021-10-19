using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.ObserverDocView
{
    // A táblázat adatait tároló dokumentum (subject).
    // A document ősből származik, onnan örököl bizonyos műveleteket.
    // Tagváltozókban tárolja az állapotot.
    class ExcelDocument: Document
    {
        public const int RowCount = 5;
        public const int ColCount = 5;
        double[,] data = new double[ColCount, RowCount];

        // Lehetővé teszi a nézeteknek (observers) és mindenki másnak az adatok
        // megváltoztatását.
        public void SetCellData(int col, int row, double value)
        {
            if (col >= ColCount) throw new ArgumentException("col >= " + ColCount);
            if (row >= RowCount) throw new ArgumentException("row >= " + RowCount);
            data[col, row] = value;

            // Ez a kulcsa, könnyű kifelejteni. Ha kimarad, akkor az adat megváltozásáról nem kapnak
            // a nézetek értesítést, nem frissítik magukat, vagyis a korábbi, változtatás előtti
            // adatokat mutatják a változást követően is.
            // Érdemes egy próbát tenni a kikommentelésével
            UpdateAllViews();
        }

        // Lehetővé teszi a nézeteknek (observers) az adatok elkérdezését.
        public double[,] GetData()
        {
            return data;
        }
    }
}
