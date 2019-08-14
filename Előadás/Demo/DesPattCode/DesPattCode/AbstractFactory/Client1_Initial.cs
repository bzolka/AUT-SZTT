using DesPattCode.AbstractFactory.Win10;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.AbstractFactory
{

    // Eredeti megoldás, nem használja az Abstract Factory patternt
    // Gond vele: bele vannak drótozva a UI elemek.
    // Ha át szeretnék térni Motif ablakozós rendszerre,
    // akkor az alkalmazásomat (OriginalClient osztály) számos
    // helyen módosítani kell a kódot és újra kell azt fordítani:
    // Win10Window -> OSXWindow
    // Win10Button -> OSX10Button
    // stb.
    // A megoldás: első körben cseréljük a hivatkozásokat (tagváltozók
    // közös interfészekre/ősre, ez egyszerű. Lásd Client2_UsingInterfaces
    // osztály.
    public class Client1_Initial
    {
        // GUI elemek
        private Win10Window wnd;
        private Win10Button button;
        // ...

        public void InitGUIElements()
        {
            // GUI elemek létrehozása
            wnd = new Win10Window();
            button = new Win10Button();
            //...
        }
        public void DoSomethingComplex()
        {
            // Demonstráljuk a GUI elemek kirajzolását:
            wnd.Show();
            wnd.Paint();
            button.Paint();
        }
    }
    
}
