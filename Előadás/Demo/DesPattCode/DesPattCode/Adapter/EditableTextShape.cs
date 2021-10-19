using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Adapter
{
    // Egy olyan szerkeszthető szövegdoboz alakzat, mely a TextBox-szal
    // szemben beilletszthető a DrawinEditor Shape listájába (mert a
    // Shape-ből származik).
    // Az EditableTextShape maga az Adapter osztály.
    // Az EditableTextShape nem maga valósítja meg a műveletek többségét.
    // Helyette:
    // - Példányosít és becsomagol egy TextBox osztályt
    // - A műveletek többségénél továbbhív a TextBox osztályba, delegálja
    //   a kéréseket.A példában a GetBoundingBox művelet a TextBox
    //   GetExtent-et hívja.
    class EditableTextShape : Shape
    {
        // A becsomagolt/adaptálandó osztály
        TextBox textBox;

        // ...

        public EditableTextShape(int topX, int topY, int width, int height)
        {
            textBox = new TextBox(topX, topY, width, height);
        }

        protected override Rect GetBoundingBox()
        {
            // Ez a lelke, ahol csak lehet, továbbítjuk a kérést
            // a becsomagolt/adaptálandó osztálynak, felhasználjuk
            // a kódját
            return textBox.GetExtent();
        }
    }
}
