using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.FactoryMethod.DocFx
{
    // Keretrendszer dokumentum ősosztály, az alkalmazásfejlesztőnek
    // ebből kell származtatni.
    abstract class Document
    {
        // Betölti a dokumentum tartalmát fájlból
        public abstract void Load();
        // Elmenti a dokumentum tartalmát fájlba
        public abstract void Save();
    }
}
