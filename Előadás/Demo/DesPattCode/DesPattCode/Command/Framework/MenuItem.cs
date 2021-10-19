using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Command.Framework
{
    // Egy univerzális menüelem osztály. Van egy szövege, mely
    // megjelenik a felületen, illetve kattintásra (Click
    // művelet) futtatja a beregisztrált parancs (ICommand
    // implementáció) objektumot.
    class MenuItem
    {
        string text;
        ICommand command;

        public MenuItem(string text, ICommand command)
        {
            this.text = text;
            this.command = command;
        }

        public void Click()
        {
            // A parancs futtatása az Execute művelet hívását jelenti
            // Ez minden ICommand implementáció esetén más és más.
            if (command != null)
                command.Execute();
        }
    }
}
