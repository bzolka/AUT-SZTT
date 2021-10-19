using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.CommandProcessor.Framework
{
    // Command objektumok közös interfésze.
    // Egy új parancs bevezetésekor implementálni kell:
    // meg kell írni az Execute műveletben a parancs
    // specifikus logikát, az UnExecute műveletben pedig a
    // parancs visszavonását.
    interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}
