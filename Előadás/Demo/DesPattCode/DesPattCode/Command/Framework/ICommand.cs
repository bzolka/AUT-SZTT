using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Command.Framework
{
    // Command objektumok közös interfésze.
    // Egy új parancs bevezetésekor implementálni kell:
    // meg kell írni az Execute műveletben a parancs
    // specifikus logikát.
    interface ICommand
    {
        void Execute();
    }

}
