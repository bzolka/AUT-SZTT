using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.MementoWithCommandProcessor.App
{
    // Olyan memento osztály, mely a dokumentum adott időpontbeli
    // teljes állapotát képes a tagváltozóiban tárolni. 
    class TextDocMemento
    {
        // A dokumentum szövege
        string text;
        // Az aktuális kijelölés kezdőindexe
        int selectionStartIndex;
        // Az aktuális kijelölés hossza (ha 0, nincs szöveg kijelölve)
        int selectionLenght;

        // Konstruktor, paraméterben egy dokumentum adott időpontbeli
        // állapotát várja.
        public TextDocMemento(string text,
           int selectionStartIndex, int selectionLenght)
        {
            this.text = text;
            this.selectionStartIndex = selectionStartIndex;
            this.selectionLenght = selectionLenght;
        }

        // Visszaadja az állapotot, a példánkban C# hármas tuple formájában, 
        // a szintaktika nem lényeges. Alternatívaként lehetne out
        // paramétert használni, vagy bevezetni egy dedikált "MementoState" 
        // osztályt és enek egy objektumával visszatérni, mely 
        // tagváltozóiban adná vissza a három értéket.
        public (string, int, int) GetState()
        {
            return (text, selectionStartIndex, selectionLenght);
        }
    }
}
