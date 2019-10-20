using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Strategy
{
    public interface ICancellationStrategy
    {
        bool IsCancelled();
    }
}
