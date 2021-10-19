using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Composite
{
    // Különböző típusú alakzatok közös interfésze
    // Egy Draw nevűműveletet tartalmaz- az implemetáló
    // ebben határozza meg az adott alakzat megjelenését.
    // Ha szükséges, interfész helyett lehet absztakt
    // (ős)osztály.
    interface IGraphic
    {
        void Draw();
    }
}
