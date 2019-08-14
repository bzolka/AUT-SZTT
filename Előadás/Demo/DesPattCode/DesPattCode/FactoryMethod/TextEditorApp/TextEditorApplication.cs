using DesPattCode.FactoryMethod.DocFx;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.FactoryMethod
{
    // A szövegszerkesztő alkalmazás alkalmazás osztálya.
    // (Application leszármazott)
    class TextEditorApplication : Application
    {
        // Ez a factory method (gyártó metódus).
        // Felülírja az ős CreateDocument műveletét
        // Az alkalmazás Document leszármazott osztályávak kell
        // visszatérni, ez esetünkben egy új TextDocument objektum.
        protected override Document CreateDocument()
        {
            return new TextDocument();
        }
    }
}
