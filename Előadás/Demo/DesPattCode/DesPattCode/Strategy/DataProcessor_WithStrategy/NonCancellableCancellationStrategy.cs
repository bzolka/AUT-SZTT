using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Strategy
{
    class NonCancellableCancellationStrategy : ICancellationStrategy
    {
        public bool IsCancelled()
        {
            return false;
        }
    }
}
