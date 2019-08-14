using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.AbstractFactory.OSX
{
    // A Window OXS témájú implementációja
    public class OSXWindow : Window
    {
        // Az ablak OXS témának megfelelő kirajzolásáért felel
        public override void Paint()
        {
            // Az egyszerűség kedvéért egyszerű konzolra írással "szimuláljuk"
            Console.WriteLine("Painting a Window using OXS theme");
        }
        // ...
    }

    // A Button OXS témájú implementációja
    public class OSXButton : Button
    {
        // A gomb OXS témának megfelelő kirajzolásáért felel
        public override void Paint()
        {
            // Az egyszerűség kedvéért egyszerű konzolra írással "szimuláljuk"
            Console.WriteLine("Painting a Button using OXS theme");
        }
        // ...
    }

    // A Scrollbar OXS témájú implementációja
    public class OSXScrollbar : Scrollbar
    {
        // A görgetősáv OXS témának megfelelő kirajzolásáért felel
        public override void Paint()
        {
            // Az egyszerűség kedvéért egyszerű konzolra írással "szimuláljuk"
            Console.WriteLine("Painting a Scrollbar using OXS theme");
        }
        // ...
    }

    // További felületelemek
}
