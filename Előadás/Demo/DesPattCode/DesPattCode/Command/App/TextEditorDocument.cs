using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Command.App
{
    // Egy szöveges dokumentumot reprezentál.
    // Tagváltozókban tárolja a dokuemntum adatait (szöveg, szelekció, stb.)
    // és műveleteket biztosít ezek lekérdezéséhez, menedzseléséhez.
    class TextDocument
    {
        // A fájl útvonala ahol a dokumentum tartalma 
        // perzisztálásra kerül.
        string path;

        public TextDocument(string path)
        {
            this.path = path;
        }

        public void Paste()
        {
            // Paste parancs logikája
            // ...
        }

        public void Load()
        {
            // Betöltés a path útvonal alatti fájlból
            // ...
        }
    }
}
