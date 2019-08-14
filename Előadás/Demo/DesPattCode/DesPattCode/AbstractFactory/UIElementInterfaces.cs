using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.AbstractFactory
{
    // Window absztrakt ős v. interfész
    public abstract class Window
    {
        // Az ablak adott témának megfelelő kirajzolásáért felel
        public abstract void Paint();
        public void Show() { }
        // ...

    }

    // Button absztrakt ős v. interfész
    public abstract class Button
    {
        // Az gomb adott témának megfelelő kirajzolásáért felel
        public abstract void Paint();
        // ...
    }

    // Scrollbar absztrakt ős v. interfész
    public abstract class Scrollbar
    {
        // Az görgetősáv adott témának megfelelő kirajzolásáért felel
        public abstract void Paint();
        // ...
    }

    // További felületelemek
}
