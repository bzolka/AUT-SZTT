using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Composite
{
    // Egy olyan dokumentumot reprezentál, mely különböző grafikus
    // alakzatokat tárol és kezel. Ezen grafikus alakzatok lehetnek
    // elemiek (levél, leaf), mint pl. Line, Rect, Text. Illetve
    // lehetnek összetettek, mint pl. a Panel (mely maga is tartalmazhat
    // elemi és összetett alakzatokat).
    // A Composite minta egyik alapelve, hogy egységesen kezeli
    // az elemi (Line, Rect, Text) és az összetett (Panel) objektumokat.
    // Ez a példában két pontban is megjelenik:
    // 1. Közös gyűjteményben tárolja (ez a graphics tag). Megteheti
    // mert a Panel is implementálja az IGraphic interfészt.
    // 2. A DrawAll műveletben a kirajzoló kód nem különböztetni meg
    // az elemi és összetett objektumokat (nincsenek típus szerint
    // leválogatva): mindre egységesen a Draw() műveletet hívja. 
    // A Draw az összetett Panel esetén az általa tartalmazott
    // alakzatokat rajzolja ki, pont ez volt a célunk!
    class DrawingDocument
    {
        // Közös tárolóban az elemi és összetett IGraphics objektumok
        List<IGraphic> graphics = new List<IGraphic>();

        public void Add(IGraphic g)
        {
            graphics.Add(g);
        }

        public void DrawAll()
        {
            // Egységesen rajzoluk ki az elemi és összetett IGraphics 
            // objektumokat, nincsenek típus szerint leválogatva, 
            // mindre Draw()-t hívunk.
            foreach (var g in graphics)
                g.Draw();
        }

    }
}
