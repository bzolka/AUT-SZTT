using System;
using System.Collections.Generic;
using System.Text;
using DesPattCode.MementoWithCommandProcessor.Framework;

namespace DesPattCode.MementoWithCommandProcessor.App
{
    // A Clear parancs megvalósítása (ICommand impplementáció).
    // Kitörli a dokumentum teljes tartalmát.
    // Egy memento objektumba csomagolva tárolja a dokumentum
    // adott időpontbeli teljes állapototát (lásd memento tagváltozó). 
    // A Clear parancs visszavonása során a teljes dokumentum 
    // állapotot vissza kell állítani!
    class ClearCommand : ICommand
    {
        // A kapcsolódó dokumentum
        // (ennek tartalmát törli a parancs)
        TextDocument document;

        // Egy memento objektumba csomagolva tárolja a dokumentum
        // teljes állapototát.
        TextDocMemento memento;

        public void Execute()
        {
            // Aktív dokumentum megszerzése
            document = TextEditorApp.Instance.GetActiveDocument();
            // Ha nincs aktív dokumentum, nem csinálunk semmit.
            if (document == null) return;

            // Kérünk a dokumentum objektumtól egy memento objektumot,
            // mely a dokumentum teljes állapotát tartalmazza a 
            // visszaállításhoz. Ezt elmentjük a command objektum 
            // tagváltozójába, hogy az UnExecute során elő tudjuk venni.
            memento = document.CreateMemento();
            document.Clear();
        }

        public void UnExecute()
        {
            document = TextEditorApp.Instance.GetActiveDocument();
            // Ha nincs aktív dokumentum, nem csinálunk semmit.
            if (document == null) return;

            // Visszaállítja a dokumentum állapotát a memento tag 
            // alapján. Kiolvassa a memento objektumból a dokumentum
            // korábbi állapotát.
            document.RestoreFromMemento(memento);
        }
    }
}
