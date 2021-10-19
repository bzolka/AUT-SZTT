using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Command.App
{
    class Program
    {
        // A futtatáshoz nevezzük át a függvényt Main-re
        public static void Main2()
        {
            // Létrehozzuk az alkalmazást reprezentáló TextEditorApp
            // objektumot.
            TextEditorApp app = new TextEditorApp();

            // Alkalmazás inicializálás (létrehozza a menüelemeket)
            app.InitMenu();

            // Szimuláljunk néhány felhasználói menü kattintást
            // Ezek a megfelelő, adott menüelemekhez beregisztált
            // parancsot futtaják.
            app.SimulateUserMenuClicks();
        }
    }
}
