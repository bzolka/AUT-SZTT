using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.MementoWithCommandProcessor.App
{
    // Egy szöveges dokumentumot reprezentál.
    // Tagváltozókban tárolja a dokuemntum adatait (szöveg, szelekció, stb.)
    // és műveleteket biztosít ezek lekérdezéséhez, menedzseléséhez.
    class TextDocument
    {
        // A felhasználó által begépelt szöveg
        string text = string.Empty;
        // Az aktuális kijelölés kezdőindexe
        int selectionStartIndex;
        // Az aktuális kijelölés hossza (ha 0, nincs szöveg kijelölve)
        int selectionLenght;

        // Csak kezdeti inicializálásra. (Nem engedjük használni, ha a
        // a selectionStartIndex és a selectionLenght nem nulla)
        public TextDocument(string initalText = "")
        {
            //if (selectionStartIndex != 0 || selectionLenght != 0)
            //    throw new Exception("InitText is only to be used for text " +
            //        "initialization right after document creation");
            this.text = initalText;
        }

        // Az aktuálisan kijelölt szöveget lecsréli a paraméterben megadottra.
        public void SetSelectedText(string textForSelection)
        {
            this.text =
                text.Remove(selectionStartIndex,
                         Math.Min(selectionLenght, text.Length - selectionStartIndex))
                    .Insert(selectionStartIndex, textForSelection);
        }

        // Lekérdezi a kijelölt szöveget.
        public string GetSelectedText()
        {
            return text.Substring(selectionStartIndex, selectionLenght);
        }

        // Megadhatjuk, hogy mettől és milyen hosszan legyen kijelölve
        // a szöveg (egy "éles" alkalmazásban a felhasználó ez az egérrel
        // tudja megadni, egérkezeléssel mi nem foglalkozunk).
        public void SetSelection(int startIndex, int len)
        {
            // Validálás: a selection ne tudjon "kimutatni" a szövegből.

            if (selectionStartIndex > text.Length)
                throw new ArgumentException("Invalid selectionStartIndex");
            if (selectionStartIndex + selectionLenght > text.Length)
                throw new ArgumentException("Invalid selectionLenght");

            selectionStartIndex = startIndex;
            selectionLenght = len;
        }

        // Visszadja, hogy mettől és milyen hosszan van kijelölve a szöveg.
        // C# tuple, több érték visszaadása (nem kell tudni a szintaktikát)
        public (int, int) GetSelectionRange()
        {
            return (selectionStartIndex, selectionLenght);
        }

        // Kipucolja a dokumentum teljes tartalmát.
        public void Clear()
        {
            text = string.Empty;
            selectionStartIndex = 0;
            selectionLenght = 0;
        }

        public void Dump()
        {
            if (selectionLenght == 0)
                Console.Write(text);
            else
            {
                Console.Write(text.Substring(0, selectionStartIndex));
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(text.Substring(selectionStartIndex, selectionLenght));
                Console.ResetColor();
                Console.Write(text.Substring(selectionStartIndex + selectionLenght));
                Console.WriteLine();
            }
        }

        #region Memento műveletek

        // Előállít és visszaad egy memento objektumot, mely a dokumentum aktuális
        // teljes állapotát tartalmazza a visszaállításhoz.
        public TextDocMemento CreateMemento()
        {
            return new TextDocMemento(text,
                    selectionStartIndex, selectionLenght);
        }

        // Visszaállítja a dokumentum állapotát a memento paraméter
        // alapján. Kiolvassa a memento objektumból a dokumentum
        // korábbi állapotát és erre beállítja az aktuállis állapotot
        // (a tagváltozók jelenlegi értékét állítja).
        public void RestoreFromMemento(TextDocMemento memento)
        {
            // A GetState egy 3-as tuple-t ad vissza, ezt egyből
            // "szétbontjuk" (deconstruct), a három tagváltozóba
            // kerülnek az értékek. A szintaktika lényegtelen számunkra.
            (text, selectionStartIndex, selectionLenght) = memento.GetState();
        }

        #endregion

    }
}
