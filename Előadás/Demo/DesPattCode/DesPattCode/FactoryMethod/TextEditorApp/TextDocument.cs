using DesPattCode.FactoryMethod.DocFx;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.FactoryMethod
{
    // A szövegszerkesztő alkalmazás dokuemntum osztálya.
    // (Document leszármazott)
    class TextDocument : Document
    {
        // A dokumentum által tárolt szöveg (ezt gépelte be a felhasználó)
        string text;

        // Betölti a dokumentum tartalmát fájlból
        public override void Load()
        {
            throw new NotImplementedException();
        }

        // Elmenti a dokumentum tartalmát fájlba
        public override void Save()
        {
            throw new NotImplementedException();
        }

        // Számos további művelet
        // ...
    }
}
