using DesPattCode.Command.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Command.App
{
    class PasteCommand : ICommand
    {
        public void Execute()
        {
            // Pszeudó kód
            // Ebben a példában a PasteCommand nem tartalmazza a lényegi logikát,
            // helyette továbbhív a dokumentumba.
            // doc = application.GetActiveDocument();
            // doc.Paste();

            Console.WriteLine("Paste parancs futtatva");
        }
    }
}
