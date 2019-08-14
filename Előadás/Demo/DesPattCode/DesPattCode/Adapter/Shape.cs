using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Adapter
{
    // Alakzatok közös interfésze.
    abstract class Shape
    {
        protected abstract Rect GetBoundingBox();

        // ...
    }
}
