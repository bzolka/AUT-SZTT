using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Strategy
{
    public interface ICompressionStrategy
    {
        void InitCompression();
        byte[] CompressData(byte[] data);
        void CloseCompression();
    }
}
