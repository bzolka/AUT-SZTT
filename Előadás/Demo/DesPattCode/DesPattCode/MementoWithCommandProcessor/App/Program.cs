using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.MementoWithCommandProcessor.App
{
    class Program
    {
        const string InitialText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed at turpis eros. Aenean nec ligula dignissim, faucibus magna a, vehicula ante. Sed placerat tempus purus, at tincidunt tellus feugiat vitae. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce gravida turpis id lacinia volutpat";
        static void Main2(string[] args)
        {
            // Singleton app instance megszerzése
            var app = TextEditorApp.Instance;

            app.NewDocument(InitialText);

            WriteHeader("Kezdeti szöveg, 'ipsum dolor' kijelölve:");
            var doc = app.GetActiveDocument();
            doc.SetSelection(6, 11);
            doc.Dump();
            Console.WriteLine();
            Console.ReadKey();

            WriteHeader("Clear parancs futtatása, utána üres a dokumentum: ");
            app.Clear();
            doc.Dump();
            Console.ReadKey();

            WriteHeader("Utolsó parancs visszavonása (visszakapjuk a teljes korábbi állapotot, a szöveget és a kijelölést is):");
            app.UndoLast();
            doc.Dump();
            Console.ReadKey();
        }

        public static void WriteHeader(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
