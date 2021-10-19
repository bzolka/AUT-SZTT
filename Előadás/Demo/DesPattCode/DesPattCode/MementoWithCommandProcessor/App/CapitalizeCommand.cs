using DesPattCode.MementoWithCommandProcessor.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.MementoWithCommandProcessor.App
{
    // Nagybetűssé alakítja a kijelölt az aktív dokumentumban
    // aktuálisan kijelölt szöveget (és a kijelölés megmarad)
    class CapitalizeCommand : ICommand
    {
        // Olyan adatokat tárol a command tagváltozókban, melyek
        // az UnExecute során a visszaállításhoz kellenek.
        // Az Execute műveletben állítjuk be ezeket a tagokat és
        // az UnExecute műveletben használjuk fel.

        // A kapcsolódó dokumentum.
        TextDocument document;
        // A nagybetűsített szöveg eredeti változata (vagyis a kijelölt
        // szöveg). Csak erre van szükség, nem kell a dokumentum teljes
        // szövegét elmenteni. Ezzel jelentős memóriát spórolunk.
        // Ráadásul a dokumentumtól nem is tudjuk lekérdezni a teljes
        // szövegét (a text tagja privát, és ez így is van jól).
        string originalText;
        int selectionStartIndex;
        int selectionLenght;

        public void Execute()
        {
            // Aktív dokumentum megszerzése
            document = TextEditorApp.Instance.GetActiveDocument();
            // Ha nincs aktív dokumentum, nem csinálunk semmit.
            if (document == null) return;

            // Elmentjük a dokumentumban a a kijelölt szöveget a parancs
            // objektumunk egy tagjába azért, hogy az Undo során az
            // UnExecute -ban vissza tudjuk állítani.
            originalText = document.GetSelectedText();
            // Ugyanígy el kell mentsük a dokumentum szelekció paramétereit
            // is, UnExecute során ezeket is vissza kell állítani.
            (selectionStartIndex, selectionLenght) = document.GetSelectionRange();

            // A parancs lényegi logikája:
            // Lecseréljük nagybetűsre a kijelölt szöveget
            document.SetSelectedText(originalText.ToUpper());
        }

        public void UnExecute()
        {
            if (document == null) return;
            // Vissza kell állítani mind  a szöveget mind a kijelőlést
            // a parancs futtatása előtti állapotre.
            document.SetSelection(selectionStartIndex, selectionLenght);
            document.SetSelectedText(originalText);
        }
    }
}
