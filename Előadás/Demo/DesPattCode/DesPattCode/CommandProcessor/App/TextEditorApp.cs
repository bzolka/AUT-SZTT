using System;
using System.Collections.Generic;
using System.Text;
using DesPattCode.CommandProcessor.Framework;

namespace DesPattCode.CommandProcessor.App
{
    // Magát az alkalmazást (annak "gyökerét") reprezentáló osztály.
    // Nyilvántartja a megnyitott dokumentumokat, tartalmaz egy 
    // CommandProcessor objektumot, stb.
    // Singleton, (lásd Singleton tervezési minta) elsődlegesen azért,
    // hogy egyetlen példánya az alkalmazásban bárhonnan kényelmesen 
    // elérhető legyen (pl. a parancs osztályokban is).
    class TextEditorApp
    {
        // A megnyitott dokumentumok listája
        List<TextDocument> documents = new List<TextDocument>();

        // A megnyitott dokumentumok közül mindig egy aktív
        // (amelyik előtérben van és a felhasználói bemenetet fogadja).
        TextDocument activeDocument;

        // Megjegyzés: van CommandProcessor névterünk és osztályunk is
        // A Framework névtér kiírásával egyértelműsítettük, hogy itt
        // az osztályra gondoltunk.
        readonly Framework.CommandProcessor commandProcessor = new Framework.CommandProcessor();

        #region A TextEditorApp Singleton

        // Tárolja az egyetlen példányt, kezdetben null.
        private static TextEditorApp instance = null;

        // Glogális hozzáférést biztosító statikus művelet
        public static TextEditorApp Instance
        {
            get
            {
                // Az egy példányt az első hozzáférés alkalmával
                // hozzuk létre
                if (instance == null)
                    instance = new TextEditorApp();
                return instance;
            }
        }

        private TextEditorApp() { }

        #endregion

        public TextDocument GetActiveDocument()
        {
            return activeDocument;
        }

        // Lényeges rész: létrehoz egy CapitalizeCommand parancsot
        // és a CommandProcessor segítségével futtatja
        public void CapitalizeSelection()
        {
            var cmd = new CapitalizeCommand();
            commandProcessor.ExecuteCommand(cmd);
        }

        // Lényeges rész: a CommandProcessor segítségével visszavonja
        // azu utoljára futtatott parancsot
        public void UndoLast()
        {
            commandProcessor.UnExecuteLastCommand();
        }

        // Létrehoz egy új dokumentumot és meg is teszi aktívvá
        // Megadhatunk egy kezdőszöveget: ez csak azt a célt szolgálja, 
        // hogy egyszerűbben tudjuk demonstrálni egy konzol alkalmazással
        // a minta működését.
        public void NewDocument(string initalText = "")
        {
            var doc = new TextDocument(initalText);
            documents.Add(doc);
            activeDocument = doc;
        }

        
        //public void OpenDocument()
        //{
        //    var doc = new TextDocument();
        //    doc.Load()
        //    documents.Add(doc);
        //    activeDocument = doc;
        //}
    }
}
