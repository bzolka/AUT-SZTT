using DesPattCode.Command.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Command.App
{
    class OpenCommand : ICommand
    {
        TextEditorApp app;

        public OpenCommand(TextEditorApp app)
        {
            this.app = app;
        }


        public void Execute()
        {
            string docPath = AskDocumentPath();
            if (docPath == null)
                return;

            // Pszeudó kód(a dokumentum megnyitás logikája)
            var doc = new TextDocument(docPath);
            app.AddDoc(doc);
            doc.Load();

            Console.WriteLine("Open futtatva");
        }

        string AskDocumentPath()
        {
            // A felhasználótól bekérjük a megnyitandó
            // dokumentum útvonalát
            // Az egyszerűség kedvéért csak beégetett adatot adunk vissza
            return @"c:\alma.txt";
        }
    }
}
