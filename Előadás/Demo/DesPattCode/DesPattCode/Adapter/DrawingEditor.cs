using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Adapter
{
    // Feladata az alakzatok tárolása egy közös heterogén kollekcióban,
    // valamint az alakzatok menedzselése.
    // Egy Shape listát tárol (heterogén kollekció), a TextBox nem tehető bele
    class DrawingEditor
    {
        List<Shape> shapes = new List<Shape>();

        // ...

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }
    }
}
