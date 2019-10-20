using System;
using System.Collections.Generic;
using System.Text;
using DesPattCode.Strategy;

namespace StrategyUnitTests
{
    class CallCounterCompressionStrategy : ICompressionStrategy
    {
        public int InitCompressionCount { get; private set; }
        public int CloseCompressionCount { get; private set; }
        public bool InitCompressionCalled_Before_CloseCompressionCount { get; private set; } = false;


        public void InitCompression()
        {
            InitCompressionCount++;
        }

        public void CloseCompression()
        {
            if (CloseCompressionCount == 0 && InitCompressionCount > 0)
                InitCompressionCalled_Before_CloseCompressionCount = true;
            CloseCompressionCount++;
        }

        public byte[] CompressData(byte[] data)
        {
            return null;
        }

 
    }
}
