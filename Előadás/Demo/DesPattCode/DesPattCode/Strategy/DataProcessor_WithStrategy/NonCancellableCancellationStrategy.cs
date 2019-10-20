using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Strategy
{
    public class NonCancellableCancellationStrategy : ICancellationStrategy
    {
        public bool IsCancelled()
        {
            return false;
        }
    }
}
