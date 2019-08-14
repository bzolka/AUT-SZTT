using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Strategy
{
    interface ICancellationStrategy
    {
        bool IsCancelled();
    }
}
