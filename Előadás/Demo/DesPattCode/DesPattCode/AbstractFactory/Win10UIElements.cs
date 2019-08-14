using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.AbstractFactory.Win10
{
    // A Window Win10 témájú implementációja
    public class Win10Window: Window
    {
        // Az ablak Win10 témának megfelelő kirajzolásáért felel
        public override void Paint()
        {
            // Az egyszerűség kedvéért egyszerű konzolra írással "szimuláljuk"
            Console.WriteLine("Painting a Window using Win10 theme");
        }
        // ...
    }

    // A Button Win10 témájú implementációja
    public class Win10Button : Button
    {
        // A gomb Win10 témának megfelelő kirajzolásáért felel
        public override void Paint()
        {
            // Az egyszerűség kedvéért egyszerű konzolra írással "szimuláljuk"
            Console.WriteLine("Painting a Button using Win10 theme");
        }
        // ...
    }

    // A Scrollbar Win10 témájú implementációja
    public class Win10Scrollbar : Scrollbar
    {
        // A görgetősáv Win10 témának megfelelő kirajzolásáért felel
        public override void Paint()
        {
            // Az egyszerűség kedvéért egyszerű konzolra írással "szimuláljuk"
            Console.WriteLine("Painting a Scrollbar using Win10 theme");
        }
        // ...
    }

    // További felületelemek
}
