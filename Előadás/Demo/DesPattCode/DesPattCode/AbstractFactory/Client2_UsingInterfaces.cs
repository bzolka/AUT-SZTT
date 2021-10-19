using DesPattCode.AbstractFactory.Win10;
using DesPattCode.AbstractFactory.OSX;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.AbstractFactory
{
    // A ClientInitial továbbfejlesztése.
    // A GUI elemekre már közös interfészként/ősként hivatkozik
    // (lásd tagváltozók).
    // Így ha más témára akarunk váltani, akkor ezeket a hivatkozásokat
    // már nem kell átírni.
    // De még mindig van egy nagy probléma, az InitGUIElements
    // függvénben a példányosítás még mindig közvetlenül a new operátorral
    // történik, és a new után muszáj egy konkrét témához tartozó
    // implementációt megadni. Így, ha más témára akarunk áttérni,
    // az InitGUIElements kódját még mindig módosítani kell és a kódot
    // újra kell fordítani.
    // Megoldás: Abstract Factory minta használata, lásd
    // Client3_UsingAbstractFactory osztály.
    public class Client2_UsingInterfaces
    {
        // GUI elemek, most már interfészként hivatkozzuk őket
        private Window wnd;
        private Button button;
        // ...

        public void InitGUIElements()
        {
            // GUI elemek létrehozása, itt, ha a new operátort használjuk,
            // akkor muszál konkrét témához tartozó osztályt megadni.
            // Ha témát akarunk váltani, át kell írni a sorokat a kódban.
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
