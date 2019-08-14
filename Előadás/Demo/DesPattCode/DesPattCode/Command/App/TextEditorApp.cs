using DesPattCode.Command.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Command.App
{
    // Magát az alkalmazást (annak "gyökerét") reprezentáló osztály.
    // Nyilvántartja a megnyitott dokumentumokat, tertalmazza az alkalmazás
    // menüjét, stb.
    class TextEditorApp
    {
        // A megnyitott dokumentumok listája
        List<TextDocument> documents = new List<TextDocument>();

        // Az alkalmazáshoz tartozó menü
        Menu menu = new Menu();

        // Léterhozza és felvesszi a menüelemeket a megfelelő
        // hozzájuk rendelt parancsokkal
        public void InitMenu()
        {
            menu.AddNewMenuItem("Paste", new PasteCommand());
            menu.AddNewMenuItem("Open Fil", new OpenCommand(this));
        }

        // Felhasználói menü kattintásokat szimulál
        public void SimulateUserMenuClicks()
        {
            // Szimuláljuk azt, hogy a felhasználó kattint az először beregisztált
            // menüelemen (Paste). Az ehhez a menüelemhez beregisztrált PasteCommand
            // fut le.
            menu.SimulateUserMenuClick(0);
            // Szimuláljuk azt, hogy a felhasználó kattint a másodszor beregisztált
            // menüelemen (Open). Az ehhez a menüelemhez beregisztrált OpenCommand
            // fut le.
            menu.SimulateUserMenuClick(1);
        }

        public void AddDoc(TextDocument doc)
        {
            documents.Add(doc);
        }
    }
}
