using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Proxy
{
    // A kép (Image) és a proxy (ImageProxy) közös interfésze.
    // A DocumentEditor ilyen interfészen keresztül hivatkozik 
    // a proxyra, így a proxy transzparens módon ékelődik be a 
    // kép elé (a DocumentEditor nem is tudja, hogy nem eredeti 
    // Image, hanem a ImageProxy objektumokat tartalmaz, hiszen 
    // számára mindkettő Graphic interfészként „jelenik meg”).
    interface IGraphic
    {
        void Draw();
        Size GetSize();
        void Load();
        void Save();
    }
}
