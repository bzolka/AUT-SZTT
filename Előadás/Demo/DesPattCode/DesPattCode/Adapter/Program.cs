using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Adapter
{
    // Demonstrálja a DrawingEditor használatát nagyon leegyszerűsítve.
    class Program
    {
        public static void Main2()
        {
            DrawingEditor editor = new DrawingEditor();

            // Vegyünk fel pár egyszerű alakzatot az editorba
            editor.AddShape( new LineShape(1, 1, 20, 20) );
            editor.AddShape( new RectShape(10, 10, 30, 35) );

            // Most vegyünk fel egy szerkeszthető szövegdobozt.
            // A TextBox osztályt nem tudjuk, az alábbi fodítási
            // hibát okoz, mert nem jó az interfésze (nem származik
            // a Shape-ből, és ezt nem is tudjuk megváltoztatni).
            // editor.AddShape(new TextBox(10, 10, 30, 35));

            // Helyette az EditableTextShape adapter osztályt vesszük fel,
            // amely már a Shape-ből származik.
            editor.AddShape( new EditableTextShape(10, 10, 30, 35) );

        }
    }
}
