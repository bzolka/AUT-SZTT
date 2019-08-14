using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.CommandProcessor.App
{
    class Program
    {
        const string InitialText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed at turpis eros. Aenean nec ligula dignissim, faucibus magna a, vehicula ante. Sed placerat tempus purus, at tincidunt tellus feugiat vitae. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce gravida turpis id lacinia volutpat";

        // Demonstrálja a CapitalizeCommand futtatását majd visszavonását
        // Szöveget jelöl ki (látszik is console-on!), nagybetűssé alakítja,
        // megismétli más szövegrészre, majd visszavonja mindkét lépést.
        static void Main2(string[] args)
        {
            var app = TextEditorApp.Instance;

            app.NewDocument(InitialText);

            WriteHeader("Kezdeti szöveg:");
            var doc = app.GetActiveDocument();
            doc.Dump();
            Console.WriteLine();
            Console.ReadKey();

            WriteHeader("Pár szó kijelölve ('ipsum dolor'): ");
            doc.SetSelection(6, 11);
            doc.Dump();
            Console.ReadKey();

            WriteHeader("A kijelölt szöveg nagybetűsítve:");
            // Ez létrehoz és futtat egy CapitalizeCommand parancsot!
            app.CapitalizeSelection();
            doc.Dump();
            Console.ReadKey();

            WriteHeader("Újabb szövegrész kijelölve ('consectetur'): ");
            doc.SetSelection(28, 11);
            doc.Dump();
            Console.ReadKey();

            WriteHeader("A kijelölt szöveg nagybetűsítve:");
            // Ez létrehoz és futtat egy CapitalizeCommand parancsot!
            app.CapitalizeSelection();
            doc.Dump();
            Console.ReadKey();

            WriteHeader("Utolsó parancs visszavonása:");
            app.UndoLast();
            doc.Dump();
            Console.ReadKey();

            WriteHeader("Utolsó parancs visszavonása:");
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
