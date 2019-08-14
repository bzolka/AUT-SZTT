using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Composite
{
    class Program
    {
        // A részletesebb magyarázatért lásd a DrawinDocument és
        // Panel osztályokat.
        // A Composite minta működését demonstrálja. Itt építjük fel
        // az alakzatok fastruktúráját.
        static void Main2(string[] args)
        {
            // Ez a "gyökér" objektum
            var doc = new DrawingDocument();

            // A gyökérhez adunk elemi objektumokat
            doc.Add(new Rect());
            doc.Add(new Line());
            doc.Add(new Line());

            // Egy panel, alakzatokat veszünk fel bele.
            var panel1 = new Panel();
            panel1.Add(new Rect());
            panel1.Add(new Text());
            panel1.Add(new Text());

            // Egy másik panel, alakzatokat veszünk fel
            // bele, és ebbe vesszük fel az előző panelt 
            // is !!!!
            var panel2 = new Panel();
            panel2.Add(new Text());
            panel2.Add(new Line());
            panel2.Add(new Line());
            panel2.Add(panel1);

            // A gyökérbe felvesszük a második panelt
            // és még néhány további alakzatot.
            doc.Add(panel2);
            doc.Add(new Rect());
            doc.Add(new Text());

            // Kirajzol minden elemet a fában.
            // A fában mélyebben elhelyezkedő elemeket
            // behúzva jeleníti meg.
            doc.DrawAll();
        }
    }
}
