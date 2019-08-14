using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.ObserverIntro
{
class TableView
{
    // ...

    double[,] data;
    PieChartView pieChartView;

    public void Update(double[,] data) { /* ... */ }
    public void SetCellValue(int x, int y, double value)
    {
        this.data[x, y] = value;
        pieChartView.Update(data);
    }
    public void Draw() { /* ... */ }
    }

    class PieChartView
    {
        TableView tableView;
        double[,] data;
        public void Update(double[,] data) { /* ... */ }

        public void SetCellValue(int x, int y, double value)
        {
            this.data[x, y] = value;
            tableView.Update(data);
        }

        public void Draw() { /* ... */ }
        // ...
    }
}
