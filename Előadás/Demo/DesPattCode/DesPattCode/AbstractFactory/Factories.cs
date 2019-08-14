using DesPattCode.AbstractFactory.OSX;
using DesPattCode.AbstractFactory.Win10;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.AbstractFactory
{
// Abstract Factory interfész.
// Mindegyik művelete egy a művelet nevének megfelelő vezérlőt gyárt.
// Mindegyik művelet visszatérési típusa az edott vezérlő 
// interfész/közös ős típusa (vagyis független a témától!).
interface GUIFactory
{
    Window CreateWindow();
    Button CreateButton();
    Scrollbar CreateScrollBar();
}

    // A GUIFactory Win10 implementációja, Win10 témájú felületelemeket gyárt.
    // Minden művelete egy a művelet nevének megfelelő típusú, az osztály 
    // nevének megfelelő (jelen esetben Win10) témájú felületelemet gyárt.
    class Win10GUIFactory : GUIFactory
    {
        public Window CreateWindow() { return new Win10Window(); }
        public Button CreateButton() { return new Win10Button(); }
        public Scrollbar CreateScrollBar() { return new Win10Scrollbar(); }
    }

    // A GUIFactory OSX implementációja, OSX témájú felületelemeket gyárt.
    // Minden művelete egy a művelet nevének megfelelő típusú, az osztály 
    // nevének megfelelő (jelen esetben OSX) témájú felületelemet gyárt.
    class OSXGUIFactory : GUIFactory
    {
        public Window CreateWindow() { return new OSXWindow(); }
        public Button CreateButton() { return new OSXButton(); }
        public Scrollbar CreateScrollBar() { return new OSXScrollbar(); }
    }

}
